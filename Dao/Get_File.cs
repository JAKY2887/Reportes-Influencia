using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace AutomatizacionPI.Dao
{
    public class Get_File
    {

        public static DataTable DetalleKinya;

        static CrudReporte crud = new CrudReporte();
        static DataTable Reporte = new DataTable();
        static DataTable Ganadores = new DataTable();
        static DataTable DetalleInfluencerUna = new DataTable();
        static DataTable DetalleInfluencerUnaActual = new DataTable();
        static DataTable DetalleInfluencerDos = new DataTable();
        static DataTable DetalleInfluencerDosActual = new DataTable();
        static DataTable DetalleInfluencerTres = new DataTable();
        static DataTable DetalleInfluencerTresActual = new DataTable();
        static DataTable ValidaPeriodo = new DataTable();
        static DataTable DetalleRporteNvo = new DataTable();

        static DataTable DetalleKinyaHistorico = new DataTable();
        static DataSet dato = new DataSet();
        public static string periodoActual;
        public static string dia;

        public MemoryStream _getFile(string Period_)
        {
            dato = new DataSet();
            Reporte = new DataTable();
            Ganadores = new DataTable();
            DetalleInfluencerUna = new DataTable();
            DetalleInfluencerUnaActual = new DataTable();
            DetalleInfluencerDos = new DataTable();
            DetalleInfluencerDosActual = new DataTable();
            DetalleInfluencerTres = new DataTable();
            DetalleInfluencerTresActual = new DataTable();
            DetalleRporteNvo = new DataTable();



            periodoActual = DateTime.Now.ToString("yyyyMM");
            
            int periodoSeleccionado = Int32.Parse(Period_);
            int periodoActuaHoy = Int32.Parse(periodoActual);
            if (periodoSeleccionado < periodoActuaHoy)
            {
                ValidaPeriodo = crud.ValidaPeriodoUnaDosTres(periodoSeleccionado);
                //dia = DateTime.Now.ToString("dd");
                //int dia12 = Int32.Parse(dia);

                //if (dia12 >= 12)
                //{
                
                if (ValidaPeriodo.Rows.Count > 0)
                {
                    DetalleInfluencerUna = crud.CargarDetallesUna(periodoSeleccionado);
                    DetalleInfluencerDos = crud.CargarDetallesDos(periodoSeleccionado);
                    DetalleInfluencerTres = crud.CargarDetallesTres(periodoSeleccionado);
                }
                else
                {
                    DetalleInfluencerUnaActual = crud.CargarDetallesUnaActual();
                    DetalleInfluencerDosActual = crud.CargarDetallesDosActual();
                    DetalleInfluencerTresActual = crud.CargarDetallesTresActual();
                   
                }
            }
            else
            {

                DetalleInfluencerUnaActual = crud.CargarDetallesUnaActual();
                DetalleInfluencerDosActual = crud.CargarDetallesDosActual();
                DetalleInfluencerTresActual = crud.CargarDetallesTresActual();
        }

            DetalleRporteNvo = crud.ReporteSumarioPI(periodoSeleccionado);
            Ganadores = crud.CargarReporteGnadores(Period_);
            Reporte = crud.CargarReporte(Period_);
            DetalleKinya = crud.CargarDetalleKinya(Period_);

            //if (Reporte.Rows.Count > 0 || ReporteSitemasAgua.Rows.Count > 0 || ReporteHistoSistemasAgua.Rows.Count > 0)
            if (Ganadores.Rows.Count > 0 || Reporte.Rows.Count > 0)

            {
                
                dato.Tables.Add(Ganadores);

                if (DetalleInfluencerUnaActual.Rows.Count > 0)
                {
                    DetalleInfluencerUnaActual.TableName = "DETALLE INFLUENCER UNA UNIDAD";
                    dato.Tables.Add(DetalleInfluencerUnaActual);           
                }
                else
                {
                    DetalleInfluencerUna.TableName = "DETALLE INFLUENCER UNA UNIDAD";
                    dato.Tables.Add(DetalleInfluencerUna);                   
                }
                if (DetalleInfluencerDosActual.Rows.Count > 0)
                {
                    DetalleInfluencerDosActual.TableName = "DETALLE INFLUENCER DOS UNIDADES";
                    dato.Tables.Add(DetalleInfluencerDosActual);                   
                }
                else
                {
                    DetalleInfluencerDos.TableName = "DETALLE INFLUENCER DOS UNIDADES";
                    dato.Tables.Add(DetalleInfluencerDos);
                }
                if (DetalleInfluencerTresActual.Rows.Count > 0)
                {
                    DetalleInfluencerTresActual.TableName = "DETALLE TRES O MAS UNIDADES";
                    dato.Tables.Add(DetalleInfluencerTresActual);
                }
                else
                {
                    DetalleInfluencerTres.TableName = "DETALLE TRES O MAS UNIDADES";
                    dato.Tables.Add(DetalleInfluencerTres);
                }
                dato.Tables.Add(Reporte);
                dato.Tables.Add(DetalleKinya);
                dato.Tables.Add(DetalleRporteNvo);

                Ganadores.TableName = "GANADORES";
                Reporte.TableName = "TRANSFORMACIONES MOKUTEKI";
                DetalleKinya.TableName = "DETALLE ORDENES KINYA VENTA";
                DetalleRporteNvo.TableName = "REPORTE SUMARIO";


                var file = ExportToExcel(dato);

                if (file != null)//|| file2 != null )
                {
                    return file;
                }
                else
                {


                }

                return null;
            }

            return null;
        }

        private MemoryStream ExportToExcel(DataSet _table)
        {
            MemoryStream stream;
            //string path = Path.Combine(Server.MapPath("~/temp"), name);
            //if (File.Exists(path)) { File.Delete(path); }
            //var newFile = new FileInfo(path);
            try
            {
                using (var package = new ExcelPackage())
                {
                    foreach (DataTable tablas in _table.Tables)
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(tablas.TableName);
                        //worksheet.Column(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //worksheet.Column(1).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#FF0000"));

                        //if (worksheet.Equals("GANADORES") )
                        var hi = worksheet.Workbook.Worksheets.GetEnumerator();
                        var hi2 = worksheet.GetValue(1, 1);

                        //if (worksheet.Equals("GANADORES")  )
                        if (worksheet.Name.Equals("GANADORES"))
                        {
                            worksheet.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#5B9BD5"));
                            worksheet.Cells["E1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["E1:G1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#FFD966"));
                        }
                        worksheet.Cells["A1:P1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:P1"].Style.Font.Name = "Calibri";
                        worksheet.Cells["A1:P1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:P1"].Style.Font.Color.SetColor(Color.Black);
                        //worksheet.Equals
                        //var cellcab = worksheet.Cells[13,1];
                        //var tcellcab = cellcab.RichText.Add(property.Name);
                        //tcellcab.Color = System.Drawing.Color.White;
                        //cellcab.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //cellcab.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                        worksheet.Cells["A1"].LoadFromDataTable(tablas, true);
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    }
                    //ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add();
                    ////dato.Tables.Add(Ganadores                    worksheet2.Cells["A1:N1"].Style.Font.Size = 14;
                    //worksheet2.Cells["A1:N1"].Style.Font.Name = "Calibri";
                    //worksheet2.Cells["A1:N1"].Style.Font.Bold = true;
                    //worksheet2.Cells["A1:N1"].Style.Font.Color.SetColor(Color.Black);

                    stream = new MemoryStream(package.GetAsByteArray());
                    // package.SaveAs(newFile);
                }
                return stream;

            }
            catch (Exception e)
            {
                if (e.Source != null)
                    System.Diagnostics.Debug.WriteLine("IOException source: {0}", e.Source);

                throw;
            }

        }
    }
}