using System.Data.OleDb;

namespace GEN_Planlama
{
    class OleDbBaglantisi
    {
        public OleDbConnection baglanti()
        {
            //C:\Users\w 10\Desktop\ENVANTER.xlsx
            OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\w 10\Desktop\ENVANTER.xlsx;Extended Properties='Excel 12.0 Xml; HDR = YES;'");
            baglan.Open();
            return baglan;
        }
    }
}
