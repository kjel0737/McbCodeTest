using McbCodeTest.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McbCodeTest
{
    public class MyDataConverter : IMcbDataConverter
    {
        public string ConvertDataToJson()
        {
            List<object> ReturnObjectList = new List<object>();

            using (McbDatabase context = new McbDatabase())
            {
                foreach (Item item in context.Items.Include(x => x.ItemTexts).Include(x => x.Parent))
                {
                    string ParentSku = item.Parent != null ? item.Parent.Sku : null;

                    string url = "https://mcb.dk";
                    //Sætter Navn hvis intet LogicalName
                    if (item.ItemTexts.First().LogicalName == null)
                    {
                        url += "/mproduct/" + item.Sku;
                    }
                    else
                    {
                        url += item.ItemTexts.First().LogicalName;
                    }

                    string Optoins = "?option=";
                    //hvis Slave object
                    if (ParentSku != null)
                    {

                        List<int> VariationOptions = new List<int>();
                        using (McbDatabase VariantContext = new McbDatabase())
                        {
                            IQueryable<ItemVariantOption> Variaton = VariantContext.ItemVariantOptions.Include(x => x.VariantOption).Include(x => x.VariantOption.Variant).Where(x => x.ItemId == item.Id);

                            //opbygger Url med Options
                            for (int index = 0; index < Variaton.ToList().Count(); index++)
                            {
                                Optoins += Variaton.ToList()[index].VariantOption.Id;
                                if (index < Variaton.ToList().Count - 1)
                                    Optoins += ",";
                            }

                            //bruger SortOrder Fra Variant og VariantOption
                            Variaton = Variaton.OrderBy(x => x.VariantOption.Variant.SortOrder).OrderBy(x => x.VariantOption.SortOrder);

                            foreach (ItemVariantOption v in Variaton)
                                VariationOptions.Add(v.VariantOption.Id);



                        }
                        url += Optoins;

                        //anonymt object til Slave
                        ReturnObjectList.Add(new
                        {
                            SKU = item.Sku,
                            Url = url,
                            VariantOptions = VariationOptions,
                            ParentSKU = ParentSku
                        });
                    }
                    else
                    {
                        //anonymt object til master
                        ReturnObjectList.Add(new
                        {
                            SKU = item.Sku,
                            Url = url,
                            ParentSKU = ParentSku
                        });
                    }


                }
                //returnere listen af object som Json
                return JsonConvert.SerializeObject(ReturnObjectList);
            }
        }
    }
}
