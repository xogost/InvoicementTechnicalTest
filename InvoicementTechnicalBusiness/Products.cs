using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvoicementTechincalData.Database;

namespace InvoicementTechnicalBusiness
{
    public class Products
    {
        #region Properties

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _companyId;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _cost;

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        private string _reference;

        public string Reference
        {
            get { return _reference; }
            set { _reference = value; }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private ApplicationDbContext _context = null;
        #endregion

        public Products()
        {
            this._context = new ApplicationDbContext();
        }

        public Products(int id, int companyId, string name, int cost, string reference, int quantity)
        {
            this._context = new ApplicationDbContext();
            this._id = id;
            this._companyId = companyId;
            this._name = name;
            this._cost = cost;
            this._reference = reference;
            this._quantity = quantity;
        }

        #region Public Methods
        /// <summary>
        /// This public method return a IQueryable object of type CoreProduct
        /// </summary>
        /// <returns>IQueryable Object of Type CoreProduct</returns>
        public IQueryable<CoreProduct> GetProductsByCompany()
        {
            return this.GetProductsByCompanyInner();
        }
        /// <summary>
        /// This public method return a IQueryable object of type CoreProduct
        /// </summary>
        /// <returns>IQueryable Object of Type CoreProduct</returns>
        public IQueryable<CoreProduct> GetProductsByCompany(int companyId)
        {
            return this.GetProductsByCompanyInner(companyId);
        }
        /// <summary>
        /// This public method get and return a CoreProduct Object by Id
        /// </summary>
        /// <param name="id">This is the primary key of record on Table</param>
        /// <returns>CoreProduct Object</returns>
        public CoreProduct GetProduct(int id)
        {
            return this.GetProductInner(id);
        }
        /// <summary>
        /// This public method get private properties and It add new record on table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool AddProduct()
        {
            return this.AddProductInner();
        }
        /// <summary>
        /// This public method add new record in database from parameters method
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool AddProduct(int companyId, string name, int cost, string reference, int quantity)
        {
            return this.AddProductInner(companyId, name, cost, reference, quantity);
        }
        /// <summary>
        /// This public method updated a record in table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool UpdateProduct()
        {
            return this.UpdateProductInner();
        }
        /// <summary>
        /// This public method update a record in database from parameters method
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool UpdateProduct(int id, string name, int cost, string reference, int quantity)
        {
            return this.UpdateProductInner(id, name, cost, reference, quantity);
        }
        /// <summary>
        /// This public method delete record from table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool DeleteProduct()
        {
            return this.DeleteProductInner();
        }
        /// <summary>
        /// This public method delete record from parameters method
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool DeleteProduct(int id)
        {
            return this.DeleteProductInner(id);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This private method return a IQueryable object of type CoreProduct
        /// </summary>
        /// <returns>IQueryable Object of Type CoreProduct</returns>
        private IQueryable<CoreProduct> GetProductsByCompanyInner()
        {
            IQueryable<CoreProduct> ObjCoreProduct = this._context.CoreProducts
                                                    .Where(r => r.CompanyId == this._companyId)
                                                    .AsQueryable();
            return ObjCoreProduct;
        }
        /// <summary>
        /// This private method return a IQueryable object of type CoreProduct
        /// </summary>
        /// <returns>IQueryable Object of Type CoreProduct</returns>
        private IQueryable<CoreProduct> GetProductsByCompanyInner(int companyId)
        {
            IQueryable<CoreProduct> ObjCoreProduct = this._context.CoreProducts
                                                    .Where(r => r.CompanyId == companyId)
                                                    .AsQueryable();
            return ObjCoreProduct;
        }
        /// <summary>
        /// This private method get and return a CoreProduct Object by Id
        /// </summary>
        /// <param name="id">This is the primary key of record on Table</param>
        /// <returns>CoreProduct Object</returns>
        private CoreProduct GetProductInner(int id)
        {
            CoreProduct ObjCoreProduct = this._context.CoreProducts
                                            .Where(r => r.Id == id)
                                            .FirstOrDefault();
            return ObjCoreProduct;
        }
        /// <summary>
        /// This private method get private properties and It add new record on table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool AddProductInner()
        {
            try
            {
                CoreProduct ObjCoreProduct = new CoreProduct();
                ObjCoreProduct.CompanyId = this._companyId;
                ObjCoreProduct.Name = this._name;
                ObjCoreProduct.Cost = this._cost;
                ObjCoreProduct.Reference = this._reference;
                ObjCoreProduct.Quantity = this._quantity;
                ObjCoreProduct.CreatedAt = DateTime.Now;
                this.AddInner(ObjCoreProduct);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This public method add new record in database from parameters method
        /// </summary>
        /// <param name="identification">Identification of company, as NIT in Colombia</param>
        /// <param name="name">Name of company</param>
        /// <returns>Bool value as result of transaction</returns>
        private bool AddProductInner(int companyId, string name, int cost, string reference, int quantity)
        {
            try
            {
                CoreProduct ObjCoreProduct = new CoreProduct();
                ObjCoreProduct.CompanyId = companyId;
                ObjCoreProduct.Name = name;
                ObjCoreProduct.Cost = cost;
                ObjCoreProduct.Reference = reference;
                ObjCoreProduct.Quantity = quantity;
                ObjCoreProduct.CreatedAt = DateTime.Now;
                this.AddInner(ObjCoreProduct);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// This private method execute add trigger on db context
        /// </summary>
        /// <param name="ObjCoreProduct">Object to add</param>
        private void AddInner(CoreProduct ObjCoreProduct)
        {
            this._context.CoreProducts.Add(ObjCoreProduct);
            this._context.SaveChanges();
        }
        /// <summary>
        /// This private method updated a record in table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool UpdateProductInner()
        {
            try
            {
                CoreProduct ObjCoreProduct = this._context.CoreProducts
                                                    .Where(r => r.Id == this._id)
                                                    .FirstOrDefault();
                ObjCoreProduct.Name = this._name;
                ObjCoreProduct.Cost = this._cost;
                ObjCoreProduct.Reference = this._reference;
                ObjCoreProduct.Quantity = this._quantity;
                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This private method update a record in database from parameters method
        /// </summary>
        /// <param name="id">Primary key table</param>
        /// <param name="identification">Identification of company, as NIT in Colombia</param>
        /// <param name="name">Name of company</param>
        /// <returns>Bool value as result of transaction</returns>
        private bool UpdateProductInner(int id, string name, int cost, string reference, int quantity)
        {
            try
            {
                CoreProduct ObjCoreProduct = this._context.CoreProducts
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefault();

                ObjCoreProduct.Name = name;
                ObjCoreProduct.Cost = cost;
                ObjCoreProduct.Reference = reference;
                ObjCoreProduct.Quantity = quantity;
                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This private method delete record from table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool DeleteProductInner()
        {
            try
            {
                CoreClient ObjCoreClient = this._context.CoreClients
                                                    .Where(r => r.Id == this._id)
                                                    .FirstOrDefault();
                this._context.CoreClients.Remove(ObjCoreClient);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This private method delete record from parameters method
        /// </summary>
        /// <param name="id">Primary key table</param>
        /// <returns>Bool value as result of transaction</returns>
        private bool DeleteProductInner(int id)
        {
            try
            {
                CoreProduct ObjCoreProduct = this._context.CoreProducts
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefault();
                this._context.CoreProducts.Remove(ObjCoreProduct);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
