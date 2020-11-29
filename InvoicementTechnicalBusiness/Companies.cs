using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvoicementTechincalData.Database;

namespace InvoicementTechnicalBusiness
{
    public class Companies
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

        private string _identificacion;

        public string Identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }

        private ApplicationDbContext _context = null;
        #endregion

        public Companies()
        {
            this._context = new ApplicationDbContext();
        }

        public Companies(int id, string identification, string name)
        {
            this._context = new ApplicationDbContext();
            this._id = id;
            this._identificacion = identification;
            this._name = name;
        }

        #region Public Methods
        /// <summary>
        /// This public method return a IQueryable object of type CoreCompany
        /// </summary>
        /// <returns>IQueryable Object of Type CoreCompany</returns>
        public IQueryable<CoreCompany> GetCompanies()
        {
            return this.GetCompaniesInner();
        }
        /// <summary>
        /// This public method get and return a CoreCompany Object by Id
        /// </summary>
        /// <param name="id">This is the primary key of record on Table</param>
        /// <returns>CoreCompany Object</returns>
        public CoreCompany GetCompany(int id)
        {
            return this.GetCompanyInner(id);
        }
        /// <summary>
        /// This public method get private properties and It add new record on table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool AddCompany()
        {
            return this.AddCompanyInner();
        }
        /// <summary>
        /// This public method add new record in database from parameters method
        /// </summary>
        /// <param name="identification">Identification of company, as NIT in Colombia</param>
        /// <param name="name">Name of company</param>
        /// <returns>Bool value as result of transaction</returns>
        public bool AddCompany(string identification, string name)
        {
            return this.AddCompanyInner(identification, name);
        }
        /// <summary>
        /// This public method updated a record in table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool UpdateCompany()
        {
            return this.UpdateCompanyInner();
        }
        /// <summary>
        /// This public method update a record in database from parameters method
        /// </summary>
        /// <param name="id">Primary key table</param>
        /// <param name="identification">Identification of company, as NIT in Colombia</param>
        /// <param name="name">Name of company</param>
        /// <returns>Bool value as result of transaction</returns>
        public bool UpdateCompany(int id, string identification, string name)
        {
            return this.UpdateCompanyInner(id, identification, name);
        }
        /// <summary>
        /// This public method delete record from table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        public bool DeleteCompany()
        {
            return this.DeleteCompanyInner();
        }
        /// <summary>
        /// This public method delete record from parameters method
        /// </summary>
        /// <param name="id">Primary key table</param>
        /// <returns>Bool value as result of transaction</returns>
        public bool DeleteCompany(int id)
        {
            return this.DeleteCompanyInner(id);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This private method return a IQueryable object of type CoreCompany
        /// </summary>
        /// <returns>IQueryable Object of Type CoreCompany</returns>
        private IQueryable<CoreCompany> GetCompaniesInner()
        {
            IQueryable<CoreCompany> ObjCoreCompany = this._context.CoreCompanies;
            return ObjCoreCompany;
        }
        /// <summary>
        /// This private method get and return a CoreCompany Object by Id
        /// </summary>
        /// <param name="id">This is the primary key of record on Table</param>
        /// <returns>CoreCompany Object</returns>
        private CoreCompany GetCompanyInner(int id)
        {
            CoreCompany ObjCoreCompany = this._context.CoreCompanies
                                            .Where(r => r.Id == id)
                                            .FirstOrDefault();
            return ObjCoreCompany;
        }
        /// <summary>
        /// This private method get private properties and It add new record on table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool AddCompanyInner()
        {
            try
            {
                CoreCompany ObjCoreCompany = new CoreCompany();
                ObjCoreCompany.Identification = this._identificacion;
                ObjCoreCompany.Name = this._name;
                ObjCoreCompany.CreatedAt = DateTime.Now;
                this.AddInner(ObjCoreCompany);
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
        private bool AddCompanyInner(string identification, string name)
        {
            try
            {
                CoreCompany ObjCoreCompany = new CoreCompany();
                ObjCoreCompany.Identification = identification;
                ObjCoreCompany.Name = name;
                ObjCoreCompany.CreatedAt = DateTime.Now;
                this.AddInner(ObjCoreCompany);
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
        /// <param name="ObjCoreCompany">Object to add</param>
        private void AddInner(CoreCompany ObjCoreCompany)
        {
            this._context.CoreCompanies.Add(ObjCoreCompany);
            this._context.SaveChanges();
        }
        /// <summary>
        /// This private method updated a record in table
        /// </summary>
        /// <returns>Bool value as result of transaction</returns>
        private bool UpdateCompanyInner()
        {
            try
            {
                CoreCompany ObjCoreCompany = this._context.CoreCompanies
                                                    .Where(r => r.Id == this._id)
                                                    .FirstOrDefault();
                ObjCoreCompany.Identification = this._identificacion;
                ObjCoreCompany.Name = this._name;
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
        private bool UpdateCompanyInner(int id, string identification, string name)
        {
            try
            {
                CoreCompany ObjCoreCompany = this._context.CoreCompanies
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefault();

                ObjCoreCompany.Identification = identification;
                ObjCoreCompany.Name = name;
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
        private bool DeleteCompanyInner()
        {
            try
            {
                CoreCompany ObjCoreCompany = this._context.CoreCompanies
                                                    .Where(r => r.Id == this._id)
                                                    .FirstOrDefault();
                this._context.CoreCompanies.Remove(ObjCoreCompany);
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
        private bool DeleteCompanyInner(int id)
        {
            try
            {
                CoreCompany ObjCoreCompany = this._context.CoreCompanies
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefault();
                this._context.CoreCompanies.Remove(ObjCoreCompany);
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
