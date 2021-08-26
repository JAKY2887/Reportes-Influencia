using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutomatizacionPI
{
    public class CrudReporte
    {
        public DataTable tablaReporte = new DataTable();
        public DataTable tablaGanadores = new DataTable();
        public DataTable tablaDetalleUna = new DataTable();
        public DataTable tablaDetalleUnaActual = new DataTable();
        public DataTable tablaDetalleDos = new DataTable();
        public DataTable tablaDetalleDosActual = new DataTable();
        public DataTable tablaDetalleTres = new DataTable();
        public DataTable tablaDetalleTresActual = new DataTable();
        public DataTable tablaReporteSistemasAgua = new DataTable();
        public DataTable tablaReporteHistoSistemasAgua = new DataTable();
        public DataTable tablaReporteKinya= new DataTable();
        public DataTable PeriodoTable = new DataTable();
        public DataTable tablaDetalleSumario = new DataTable();

        public int ValidaPreeliminar()
        {
            int i = 0;
            return i;
        }
        public DataTable ReporteSumarioPI(int periodo)
        {
            tablaDetalleSumario = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid as'Código Influencer',AssociateName as 'Nombre',Sponsorid as 'Código Patrocinador',AssociateWin as'Código Ganador',Pais,Ordernum as 'OV',TipDoc,ItemCode as'Codigo venta',Descripcion,Qty as'Cantidad',Bono_Kinya,Bono_Influencia,Bono_Mokuteki,TotalAmount as 'Total',OrderDate as'Fecha Orden' ,Period from[NIKKENCHALLENGE].[dbo].[Details_PI] where Period =" + periodo;
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    IAsyncResult res = cmd.BeginExecuteReader();
                    IDataReader dr = cmd.EndExecuteReader(res);
                    tablaDetalleSumario.Load(dr);
                    conn.Close();
                    return tablaDetalleSumario;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        public DataTable ValidaPeriodoUnaDosTres(int periodo)
        {
            PeriodoTable = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Periodo From NIKKENCHALLENGE.[dbo].[Historico_Influencer_UNA] where Periodo="+ periodo;
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    IAsyncResult res = cmd.BeginExecuteReader();
                    IDataReader dr = cmd.EndExecuteReader(res);
                    PeriodoTable.Load(dr);
                    conn.Close();
                    return PeriodoTable;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }

        public DataTable CargarReporteGnadores(string periodo)
        {
            tablaGanadores = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid ,Influencer AS 'Ganancia Bono Influencia del Mes',	Pais,Period,comentarios,GananciaKinya,Total as 'Total Periodo "+periodo+"' From NIKKENCHALLENGE.dbo.Win_PlanInfluencia (" + periodo+")";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    IAsyncResult res = cmd.BeginExecuteReader();
                    IDataReader dr = cmd.EndExecuteReader(res);
                    tablaGanadores.Load(dr);
                    conn.Close();
                    return tablaGanadores;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }

        public DataTable CargarDetallesUna(int periodo)
        {
            tablaDetalleUna = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid,Ordernum,Fecha_Orden, Periodo, Kit_Influencer,Descripcion, Qty_Item, Bono_Una_Unidad,Owner_Influencer,CASE WHEN Owner_Country = 'LAT' THEN 'MEX' ELSE Owner_Country END as Owner_Country from NIKKENCHALLENGE.[dbo].[Historico_Influencer_UNA] where periodo ="+ periodo ;
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaDetalleUna);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaDetalleUna;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }

        public DataTable CargarDetallesUnaActual()
        {
            tablaDetalleUnaActual = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid,Ordernum,Fecha_Orden, Periodo, Kit_Influencer,Descripcion, Qty_Item, Bono_Una_Unidad,Owner_Influencer,CASE WHEN Owner_Country = 'LAT' THEN 'MEX' ELSE Owner_Country END as Owner_Country from NIKKENCHALLENGE.[dbo].[Influencer_UNA]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaDetalleUnaActual);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaDetalleUnaActual;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        public DataTable CargarDetallesDos(int periodo)
        {
            tablaDetalleDos = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid,Ordernum,ORderDate, Periodo, itemcode,Descripcion, Qty_Item, Bono_Dos_Unidades,Owner_Influencer,CASE WHEN Owner_Country = 'LAT' THEN 'MEX' ELSE Owner_Country END as Owner_Country from NIKKENCHALLENGE.[dbo].[Historico_Influencer_DOS] where periodo =" + periodo;
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaDetalleDos);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaDetalleDos;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        public DataTable CargarDetallesDosActual()
        {
            tablaDetalleDosActual = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid,Ordernum,ORderDate, Periodo, itemcode,Descripcion, Qty_Item, Bono_Dos_Unidades,Owner_Influencer,CASE WHEN Owner_Country = 'LAT' THEN 'MEX' ELSE Owner_Country END as Owner_Country from NIKKENCHALLENGE.[dbo].[Influencer_DOS] ";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaDetalleDosActual);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaDetalleDosActual;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        public DataTable CargarDetallesTres(int periodo)
        {
            tablaDetalleTres = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid,Ordernum,ORderDate, Periodo, itemcode,Descripcion, Qty_Item, Bono_Tres_Unidades_o_Mas,Owner_Influencer,CASE WHEN Owner_Country = 'LAT' THEN 'MEX' ELSE Owner_Country END as Owner_Country from NIKKENCHALLENGE.[dbo].[Historico_Influencer_TRESoMAS] where periodo =" + periodo;
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaDetalleTres);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaDetalleTres;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        public DataTable CargarDetallesTresActual()
        {
            tablaDetalleTresActual = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid,Ordernum,ORderDate, Periodo, itemcode,Descripcion, Qty_Item, Bono_Tres_Unidades_o_Mas,Owner_Influencer,CASE WHEN Owner_Country = 'LAT' THEN 'MEX' ELSE Owner_Country END as Owner_Country from NIKKENCHALLENGE.[dbo].[Influencer_TRESoMAS]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaDetalleTresActual);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaDetalleTresActual;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        public DataTable CargarDetalleKinya(string periodo)
        {
            tablaReporteKinya = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select * from NIKKENCHALLENGE.DBO.Details_kinya("+ periodo+ ")";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    IAsyncResult res = cmd.BeginExecuteReader();
                    IDataReader dr = cmd.EndExecuteReader(res);
                    tablaReporteKinya.Load(dr);
                    conn.Close();
                    return tablaReporteKinya;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }
        }
        public DataTable CargarReporte(string periodo)
        {
            tablaReporte = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
                {
                    conn.Open();
                    string strSql;
                    strSql = "select Associateid, AssociateName,Descripcion as 'Ingreso', ordernum_Transformado,TipDoc,Kit_Transformado,Descripcion_Transformado,Qty_Transformado,Pais,Period,OrderDate_Transformado,Sponsorid,SponsoridCountry,Bono from dbo.incorporados_1usd where transformacion = 1 and period ="+periodo;
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandText = strSql;
                    //cmd.ExecuteNonQuery();
                    SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
                    adap.Fill(tablaReporte);
                    //con = Convert.ToInt32(cmd.ExecuteScalar());
                    return tablaReporte;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex);

                throw;
            }

        }
        //public DataTable CargarReporteSistemaAgua()
        //{
        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
        //        {
        //            conn.Open();
        //            string strSql;
        //            strSql = "select Associateid, AssociateType, Ordernum, TipDoc, ITemcode, Qty, CASE WHEN Pais='LAT' THEN 'MEX' ELSE Pais END as 'Pais', Period, orderdate, linenum from[NIKKENCHALLENGE].[dbo].[Detail_NKChallenge]";
        //            SqlCommand cmd = new SqlCommand(strSql, conn);
        //            cmd.CommandText = strSql;
        //            //cmd.ExecuteNonQuery();
        //            SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
        //            adap.Fill(tablaReporteSistemasAgua);
        //            //con = Convert.ToInt32(cmd.ExecuteScalar());
        //            return tablaReporteSistemasAgua;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("error" + ex);

        //        throw;
        //    }

        //}
        //public DataTable CargarReporteHistoricoSistemaAgua(string periodo)
        //{
        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conecBD"].ConnectionString))
        //        {
        //            conn.Open();
        //            string strSql;
        //            strSql = " select Associateid, AssociateType, Ordernum, TipDoc, ITemcode, Qty, CASE WHEN Pais = 'LAT' THEN 'MEX' ELSE Pais END as 'pais',Period, orderdate, linenum from[NIKKENCHALLENGE].[dbo].[Historico_Detail_NKChallenge] where period = " +periodo;
        //            SqlCommand cmd = new SqlCommand(strSql, conn);
        //            cmd.CommandText = strSql;
        //            //cmd.ExecuteNonQuery();
        //            SqlDataAdapter adap = new SqlDataAdapter(strSql, conn);
        //            adap.Fill(tablaReporteHistoSistemasAgua);
        //            //con = Convert.ToInt32(cmd.ExecuteScalar());
        //            return tablaReporteHistoSistemasAgua;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("error" + ex);

        //        throw;
        //    }

        //}
    }
}