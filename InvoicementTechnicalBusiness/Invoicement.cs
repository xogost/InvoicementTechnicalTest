using InvoicementTechincalData.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InvoicementTechnicalBusiness
{
    public class Invoicement
    {
        #region Properties
        private int _companyId;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private int _clientId;

        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private CoreProduct[] _products;

        public CoreProduct[] Products
        {
            get { return _products; }
            set { _products = value; }
        }
        private ApplicationDbContext _context = null;
        #endregion
        public Invoicement()
        {
            this._context = new ApplicationDbContext();
        }
        #region Public methods

        /// <summary>
        /// This public method return a IQueryable object of type CoreInvoice
        /// </summary>
        /// <returns>IQueryable Object of Type CoreInvoice</returns>
        public IQueryable<CoreInvoice> GetInvoices()
        {
            return this.GetInvoicesInner();
        }
        /// <summary>
        /// This public method create a new invoice
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool CreateInvoice()
        {
            return this.CreateInvoiceInner();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This private method return a IQueryable object of type CoreInvoice
        /// </summary>
        /// <returns>IQueryable Object of Type CoreInvoice</returns>
        private IQueryable<CoreInvoice> GetInvoicesInner()
        {
            return this._context.CoreInvoices.AsQueryable();
        }
        /// <summary>
        /// This private method create a new invoice
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool CreateInvoiceInner() {
            CoreInvoice ObjCoreInvoice = new CoreInvoice();
            ObjCoreInvoice.CompanyId = this._companyId;
            ObjCoreInvoice.CreatedAt = DateTime.Now;
            this._context.CoreInvoices.Add(ObjCoreInvoice);
            this._context.SaveChanges();

            CoreInvoiceCoreClient objCoreInvoiceCoreClient = new CoreInvoiceCoreClient();
            objCoreInvoiceCoreClient.InvoiceId = ObjCoreInvoice.Id;
            objCoreInvoiceCoreClient.ClientId = this._clientId;
            objCoreInvoiceCoreClient.Total = (int)this._total;
            ObjCoreInvoice.CreatedAt = DateTime.Now;
            this._context.CoreInvoiceCoreClients.Add(objCoreInvoiceCoreClient);
            this._context.SaveChanges();

            foreach (var item in this._products)
            {
                CoreInvoiceCoreProduct ObjCoreInvoiceCoreProduct = new CoreInvoiceCoreProduct();
                ObjCoreInvoiceCoreProduct.InvoiceId = ObjCoreInvoice.Id;
                ObjCoreInvoiceCoreProduct.ProductId = item.Id;
                ObjCoreInvoice.CreatedAt = DateTime.Now;
                this._context.CoreInvoiceCoreProducts.Add(ObjCoreInvoiceCoreProduct);
                this._context.SaveChanges();
            }

            return true;
        }
        #endregion

    }
}
