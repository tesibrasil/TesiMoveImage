using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MoveImages
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> obrs = new List<string>();
            obrs.Add(@"//hslpaTHOXH01/TESI/ScanRequest/OBR27");
            obrs.Add(@"//hslpaTHOXH01/TESI/ScanRequest/OBR28");
            obrs.Add(@"//hslpaTHOXH01/TESI/ScanRequest/OBR29");
            obrs.Add(@"//hslpaTHOXH01/TESI/ScanRequest/OBR30");

            string destino = @"//hslpaTHOXH01/TESI/ScanRequest/";

            foreach (var folder in obrs)
            {
                List<string> obrxImages = Directory.GetFiles(folder, "*.TIF").ToList();

                if(obrxImages.Count() > 0)
                {
                    foreach (var file in obrxImages)
                    {
                        string filename = Path.GetFileName(file);
                        string imagemDestino = destino + filename;
                     
                        if (!File.Exists(imagemDestino))
                        {
                            try
                            {
                                File.Move(file, imagemDestino);
                            }
                            catch (IOException iox)
                            {
                                Console.WriteLine(iox.Message);
                            }
                        }

                    }
                }

            }

        }
    }
}
