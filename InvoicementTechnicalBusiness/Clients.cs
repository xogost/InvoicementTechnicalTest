using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvoicementTechincalData.Database;

namespace InvoicementTechnicalBusiness
{
    public class Clients
    {
        #region Properties

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private int _companyId;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private ApplicationDbContext _context = null;
        #endregion

        public Clients()
        {
            this._context = new ApplicationDbContext();
        }

        public Clients(int id, string name, int age, int companyId)
        {
            this._context = new ApplicationDbContext();
            this._id = id;
            this._name = name;
            this._age = age;
            this._companyId = companyId;
        }

        #region Public Methods
        /// <summary>
        /// This public method return a IQueryable object of type CoreClient
        /// </summary>
        /// <returns>IQueryable Object of Type CoreClient</returns>
        public IQueryable<CoreClient> GetClientsByCompany()
        {
            return this.GetClientsByCompanyInner();
        }
        /// <summary>
        /// This public method return a IQueryable object of type CoreClient
        /// </summary>
        /// <returns>IQueryable Object of Type CoreClient</returns>
        public IQueryable<CoreClient> GetClientsByCompany(int companyId)
        {
            return this.GetClientsByCompanyInner(companyId);
        }
        /// <summary>
        /// This public method get and return a CoreClient Object by Id
        /// </summary>
        /// <param name="id">This is the primary key of record on Table</param>
        /// <returns>CoreClient Object</returns>
        public CoreClient GetClient(int id)
        {
            return this.GetClientInner(id);
        }
        /// <summary>
        /// This public method get private properties and It add new record on table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool AddClient()
        {
            return this.AddClientInner();
        }
        /// <summary>
        /// This public method add new record in database from parameters method
        /// </summary>
        /// <param name="name">Name of company</param>
        /// <param name="age">Client Age</param>
        /// <returns>Bool value as result of transaction</returns>
        public bool AddClient(string name, int age, int companyId)
        {
            return this.AddClientInner(name, age, companyId);
        }
        /// <summary>
        /// This public method updated a record in table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool UpdateClient()
        {
            return this.UpdateClientInner();
        }
        /// <summary>
        /// This public method update a record in database from parameters method
        /// </summary>
        /// <param name="id">Primary key table</param>
        /// <param name="name">Name of company</param>
        /// <param name="age">Client Age</param>
        /// <returns>Bool value as result of transaction</returns>
        public bool UpdateClient(int id, string name, int age)
        {
            return this.UpdateClientInner(id, name, age);
        }
        /// <summary>
        /// This public method delete record from table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool DeleteClient()
        {
            return this.DeleteClientInner();
        }
        /// <summary>
        /// This public method delete record from parameters method
        /// </summary>
        /// <param name="id">Primary key table</param>
        /// <returns>Bool value as result of transaction</returns>
        public bool DeleteClient(int id)
        {
            return this.DeleteClientInner(id);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This private method return a IQueryable object of type CoreClient
        /// </summary>
        /// <returns>IQueryable Object of Type CoreClient</returns>
        private IQueryable<CoreClient> GetClientsByCompanyInner()
        {
            IQueryable<CoreClient> ObjCoreClient = this._context.CoreClients
                                                    .Where(r => r.CompanyId == this._companyId)
                                                    .AsQueryable(); ;
            return ObjCoreClient;
        }
        /// <summary>
        /// This private method return a IQueryable object of type CoreClient
        /// </summary>
        /// <returns>IQueryable Object of Type CoreClient</returns>
        private IQueryable<CoreClient> GetClientsByCompanyInner(int companyId)
        {
            IQueryable<CoreClient> ObjCoreClient = this._context.CoreClients
                                                    .Where(r => r.CompanyId == companyId)
                                                    .AsQueryable();
            return ObjCoreClient;
        }
        /// <summary>
        /// This private method get and return a CoreClient Object by Id
        /// </summary>
        /// <param name="id">This is the primary key of record on Table</param>
        /// <returns>CoreClient Object</returns>
        private CoreClient GetClientInner(int id)
        {
            CoreClient ObjCoreClient = this._context.CoreClients
                                            .Where(r => r.Id == id)
                                            .FirstOrDefault();
            return ObjCoreClient;
        }
        /// <summary>
        /// This private method get private properties and It add new record on table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool AddClientInner()
        {
            try
            {
                CoreClient ObjCoreClient = new CoreClient();
                ObjCoreClient.Name = this._name;
                ObjCoreClient.Age = this._age;
                ObjCoreClient.CompanyId = this._companyId;
                ObjCoreClient.CreatedAt = DateTime.Now;
                this.AddInner(ObjCoreClient);
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
        /// <param name="name">Name of company</param>
        /// <param name="age">Client age</param>
        /// <returns>Bool value as result of transaction</returns>
        private bool AddClientInner(string name, int age, int companyId)
        {
            try
            {
                CoreClient ObjCoreClient = new CoreClient();
                ObjCoreClient.Name = name;
                ObjCoreClient.Age = age;
                ObjCoreClient.CompanyId = companyId;
                ObjCoreClient.CreatedAt = DateTime.Now;
                this.AddInner(ObjCoreClient);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This private method execute add trigger on db context
        /// </summary>
        /// <param name="ObjCoreClient">Object to add</param>
        private void AddInner(CoreClient ObjCoreClient)
        {
            this._context.CoreClients.Add(ObjCoreClient);
            this._context.SaveChanges();
        }
        /// <summary>
        /// This private method updated a record in table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool UpdateClientInner()
        {
            try
            {
                CoreClient ObjCoreClient = this._context.CoreClients
                                                    .Where(r => r.Id == this._id)
                                                    .FirstOrDefault();
                ObjCoreClient.Name = this._name;
                ObjCoreClient.Age = this._age;
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
        /// <param name="name">Name of company</param>
        /// <param name="age">Client age</param>
        /// <returns>Bool value as result of transaction</returns>
        private bool UpdateClientInner(int id, string name, int age)
        {
            try
            {
                CoreClient ObjCoreClient = this._context.CoreClients
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefault();

                ObjCoreClient.Name = name;
                ObjCoreClient.Age = age;
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
        private bool DeleteClientInner()
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
        private bool DeleteClientInner(int id)
        {
            try
            {
                CoreClient ObjCoreClient = this._context.CoreClients
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefault();
                this._context.CoreClients.Remove(ObjCoreClient);
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
