using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;


namespace BLL
{
    public class MaterialBusiness 
    {
        public void CreateMaterial(tbl_Material M)
        {
            try
            {
                MaterialDB MD = new MaterialDB();
                MD.CreateMaterial(M);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public List<WorkShopMaterial> GetMaterials()
        {
            try
            {
                MaterialDB MD = new MaterialDB();
                return MD.GetMaterials();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
}
}
