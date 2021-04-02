using MologWMSOpenApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace MologWMSOpenApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var appKey = "0000000000000000";
            var appSecret = "TESTaytGjOqduSZnZDymxhPWgezyiMYr";
            var username = "user1";
            var password = "user@pass123";
            var client = new MologWMSOpenApiClient(appKey, appSecret);

            // Create Token API
            await client.CreateToken(username, password);

            // If Access Token is expired, you can use refresh token
            await client.RefreshToken();

            /*
            var inventoryList = await client.Inventory.Select(new Dictionary<string, object> {
                { "PAGE", 1 },
                { "SIZE", 10 },
               { "RECEIVED_DATE_FROM", "2021-03-23T00:00:00+07:00" },
               // { "RECEIVED_DATE_TO", "2021-03-23T23:59:59+07:00" },
               // { "SKU_CODE", "PILLOWB001" },
               // { "ON_HAND_ONLY", "true" }
            });
            

            
            var pickByJob = await client.Picked.SelectByJob(new Dictionary<string, object> {
                { "Rel1 No", "QQ" },
            });
            
            var packByJob = await client.Packed.SelectByJob(new Dictionary<string, object> {
                { "Rel1 No", "QQ" },
            });

            var shipByJob = await client.Shipped.SelectByJob(new Dictionary<string, object> {
                { "Rel1 No", "QQ" },
            });
            
            var grByJob = await client.GR.SelectByJob(new Dictionary<string, object> {
                { "Rec1 No", "QQ" },
            });
            
            
            var crosscheckASN = await client.Crosscheck.SelectASN(new Dictionary<string, object> {
                { "CREATE_DATE_FROM", "2021-03-23T00:00:00+07:00" },
                { "CREATE_DATE_TO", "2021-03-23T23:59:59+07:00" },
            });

            var crosscheckDSO = await client.Crosscheck.SelectDSO(new Dictionary<string, object> {
                { "CREATE_DATE_FROM", "2021-03-23T00:00:00+07:00" },
                { "CREATE_DATE_TO", "2021-03-23T23:59:59+07:00" },
            });
            

            
            var createPartner = await client.Partner.CreateUpdate(new Dictionary<string, object> {
                { "DATA", new[] {
                        new Dictionary<string, object> {
                            { "ACTIVE", true },
                            { "CODE", "ITH5" },
                            { "COMPANY_NAME", "AAA"}
                        }
                    }
                }
            });
            

            
            var createSKU = await client.SKU.CreateUpdate(new Dictionary<string, object> {
                { "DATA", new[] {
                        new Dictionary<string, object> {
                            { "SKU_CODE", "ABC0001" },
                            { "ACTIVE", true },
                            { "STORAGE_TYPE", "AMBIENT"},
                            { "STORAGE_CAT_SERVICE", "GENERAL"},
                            { "PRODUCT_TYPE", "NORMAL"},
                            { "PICK_BY_CODE", "FIFO"},
                            { "CBM_RATIO", "1"},
                            { "BOM_SKU", false},
                            { "DEFAULT_EXPIRY", false},
                            { "DIMENSION", new[] {
                                    new Dictionary<string, object> {
                                        {"SKU_LEVEL", "1"},
                                        {"PACK_CODE", "PCS"},
                                        {"PACK_QTY", "3"},
                                        {"DEF_PACK", true},
                                        {"LENGTH", "1.5"},
                                        {"WIDTH", "1.5"},
                                        {"HEIGHT", "1"},
                                        {"LENGTH_UOM", "CM"},
                                        {"VOLUME", "1"},
                                        {"VOLUME_UOM", "CBM"},
                                        {"NET_WEIGHT", "1"},
                                        {"GROSS_WEIGHT", "1"},
                                        {"WEIGHT_UOM", "KG"},
                                    }
                                }
                            }
                        }
                    }
                }
            });

            var updateBOM = await client.SKU.UpdateBOM(new Dictionary<string, object> {
                { "DATA", new[] {
                        new Dictionary<string, object> {
                            { "SKU_CODE", "ABC0001" },
                            { "CHILDREN", new[] {
                                    new Dictionary<string, object> {
                                        {"CHILD_SKU_CODE", "PILLOWB001"},
                                        {"QTY", "2"},
                                    }
                                }
                            }
                        }
                    }
                }
            });
            

            
            var createASN = await client.ASN.Create(new Dictionary<string, object> {
                { "Rec1 No", "REC0000000001" },
                { "EXP_RECEIVED_DATE", "2021-03-23T00:00:00+07:00" },
                { "DETAIL", new[] {
                        new Dictionary<string, object> {
                            { "SKU_CODE", "PILLOWB001" },
                            { "RECEIVED_QTY", "10" }
                        }
                    }
                }
            });
            

            
            var createPSO = await client.PSO.Create(new Dictionary<string, object> {
                { "Rel1 No", "REC0000000001" },
                { "PSO_DATE", "2021-03-23T00:00:00+07:00" },
                { "DETAIL", new[] {
                        new Dictionary<string, object> {
                            { "SKU_CODE", "PILLOWB001" },
                            { "RELEASE_QTY", "10" }
                        }
                    }
                }
            });
            

            
            var createDSO = await client.DSO.Create(new Dictionary<string, object> {
                { "Rel1 No", "REC0000000002" },
                { "PSO_DATE", "2021-03-23T00:00:00+07:00" },
                { "DETAIL", new[] {
                        new Dictionary<string, object> {
                            { "SKU_CODE", "PILLOWB001" },
                            { "RELEASE_QTY", "10" }
                        }
                    }
                }
            });

            var updateConsigneeShipToDSO = await client.DSO.UpdateConsigneeShipTo(new Dictionary<string, object> {
                { "Rel1 No", "REC0000000002" },
                { "CON_CODE", "ITH5" },
            });

            var updateInvoiceDSO = await client.DSO.UpdateInvoice(new Dictionary<string, object> {
                { "Rel1 No", "REC0000000002" },
                { "INVOICE_NO", "INV0000000001" },
            });

            var cancelDSO = await client.DSO.Cancel(new Dictionary<string, object> {
                { "Rel1 No", "REC0000000002" },
            });
            */

            // If you want sign out on Open API
            var deleteTokenResult = await client.DeleteToken();
        }
    }
}
