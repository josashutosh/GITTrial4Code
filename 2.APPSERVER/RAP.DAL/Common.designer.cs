﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RAP.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OAKRAP")]
	public partial class CommonDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUserInfo(UserInfo instance);
    partial void UpdateUserInfo(UserInfo instance);
    partial void DeleteUserInfo(UserInfo instance);
    partial void InsertState(State instance);
    partial void UpdateState(State instance);
    partial void DeleteState(State instance);
    partial void InsertErrorLog(ErrorLog instance);
    partial void UpdateErrorLog(ErrorLog instance);
    partial void DeleteErrorLog(ErrorLog instance);
    partial void InsertDocument(Document instance);
    partial void UpdateDocument(Document instance);
    partial void DeleteDocument(Document instance);
    #endregion
		
		public CommonDataContext() : 
				base(global::RAP.DAL.Properties.Settings.Default.OAKRAPConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CommonDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CommonDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CommonDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CommonDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<UserInfo> UserInfos
		{
			get
			{
				return this.GetTable<UserInfo>();
			}
		}
		
		public System.Data.Linq.Table<State> States
		{
			get
			{
				return this.GetTable<State>();
			}
		}
		
		public System.Data.Linq.Table<ErrorLog> ErrorLogs
		{
			get
			{
				return this.GetTable<ErrorLog>();
			}
		}
		
		public System.Data.Linq.Table<Document> Documents
		{
			get
			{
				return this.GetTable<Document>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserInfo")]
	public partial class UserInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _AddressLine1;
		
		private string _AddressLine2;
		
		private string _City;
		
		private int _StateID;
		
		private int _Zip;
		
		private string _PhoneNumber;
		
		private string _ContactEmail;
		
		private System.Nullable<System.DateTime> _CreatedDate;
		
		private EntityRef<State> _State;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnAddressLine1Changing(string value);
    partial void OnAddressLine1Changed();
    partial void OnAddressLine2Changing(string value);
    partial void OnAddressLine2Changed();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnStateIDChanging(int value);
    partial void OnStateIDChanged();
    partial void OnZipChanging(int value);
    partial void OnZipChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    partial void OnContactEmailChanging(string value);
    partial void OnContactEmailChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    #endregion
		
		public UserInfo()
		{
			this._State = default(EntityRef<State>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressLine1", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string AddressLine1
		{
			get
			{
				return this._AddressLine1;
			}
			set
			{
				if ((this._AddressLine1 != value))
				{
					this.OnAddressLine1Changing(value);
					this.SendPropertyChanging();
					this._AddressLine1 = value;
					this.SendPropertyChanged("AddressLine1");
					this.OnAddressLine1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressLine2", DbType="VarChar(25)")]
		public string AddressLine2
		{
			get
			{
				return this._AddressLine2;
			}
			set
			{
				if ((this._AddressLine2 != value))
				{
					this.OnAddressLine2Changing(value);
					this.SendPropertyChanging();
					this._AddressLine2 = value;
					this.SendPropertyChanged("AddressLine2");
					this.OnAddressLine2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateID", DbType="Int NOT NULL")]
		public int StateID
		{
			get
			{
				return this._StateID;
			}
			set
			{
				if ((this._StateID != value))
				{
					if (this._State.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStateIDChanging(value);
					this.SendPropertyChanging();
					this._StateID = value;
					this.SendPropertyChanged("StateID");
					this.OnStateIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Zip", DbType="Int NOT NULL")]
		public int Zip
		{
			get
			{
				return this._Zip;
			}
			set
			{
				if ((this._Zip != value))
				{
					this.OnZipChanging(value);
					this.SendPropertyChanging();
					this._Zip = value;
					this.SendPropertyChanged("Zip");
					this.OnZipChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this.OnPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumber = value;
					this.SendPropertyChanged("PhoneNumber");
					this.OnPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContactEmail", DbType="VarChar(35)")]
		public string ContactEmail
		{
			get
			{
				return this._ContactEmail;
			}
			set
			{
				if ((this._ContactEmail != value))
				{
					this.OnContactEmailChanging(value);
					this.SendPropertyChanging();
					this._ContactEmail = value;
					this.SendPropertyChanged("ContactEmail");
					this.OnContactEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="State_UserInfo", Storage="_State", ThisKey="StateID", OtherKey="StateID", IsForeignKey=true)]
		public State State
		{
			get
			{
				return this._State.Entity;
			}
			set
			{
				State previousValue = this._State.Entity;
				if (((previousValue != value) 
							|| (this._State.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._State.Entity = null;
						previousValue.UserInfos.Remove(this);
					}
					this._State.Entity = value;
					if ((value != null))
					{
						value.UserInfos.Add(this);
						this._StateID = value.StateID;
					}
					else
					{
						this._StateID = default(int);
					}
					this.SendPropertyChanged("State");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.State")]
	public partial class State : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _StateID;
		
		private string _StateCode;
		
		private string _StateName;
		
		private EntitySet<UserInfo> _UserInfos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStateIDChanging(int value);
    partial void OnStateIDChanged();
    partial void OnStateCodeChanging(string value);
    partial void OnStateCodeChanged();
    partial void OnStateNameChanging(string value);
    partial void OnStateNameChanged();
    #endregion
		
		public State()
		{
			this._UserInfos = new EntitySet<UserInfo>(new Action<UserInfo>(this.attach_UserInfos), new Action<UserInfo>(this.detach_UserInfos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int StateID
		{
			get
			{
				return this._StateID;
			}
			set
			{
				if ((this._StateID != value))
				{
					this.OnStateIDChanging(value);
					this.SendPropertyChanging();
					this._StateID = value;
					this.SendPropertyChanged("StateID");
					this.OnStateIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateCode", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string StateCode
		{
			get
			{
				return this._StateCode;
			}
			set
			{
				if ((this._StateCode != value))
				{
					this.OnStateCodeChanging(value);
					this.SendPropertyChanging();
					this._StateCode = value;
					this.SendPropertyChanged("StateCode");
					this.OnStateCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string StateName
		{
			get
			{
				return this._StateName;
			}
			set
			{
				if ((this._StateName != value))
				{
					this.OnStateNameChanging(value);
					this.SendPropertyChanging();
					this._StateName = value;
					this.SendPropertyChanged("StateName");
					this.OnStateNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="State_UserInfo", Storage="_UserInfos", ThisKey="StateID", OtherKey="StateID")]
		public EntitySet<UserInfo> UserInfos
		{
			get
			{
				return this._UserInfos;
			}
			set
			{
				this._UserInfos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UserInfos(UserInfo entity)
		{
			this.SendPropertyChanging();
			entity.State = this;
		}
		
		private void detach_UserInfos(UserInfo entity)
		{
			this.SendPropertyChanging();
			entity.State = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ErrorLog")]
	public partial class ErrorLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ErrorID;
		
		private string _ErrorNumber;
		
		private string _ErrorMessage;
		
		private string _ErrorMessageDetails;
		
		private System.DateTime _CreatedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnErrorIDChanging(int value);
    partial void OnErrorIDChanged();
    partial void OnErrorNumberChanging(string value);
    partial void OnErrorNumberChanged();
    partial void OnErrorMessageChanging(string value);
    partial void OnErrorMessageChanged();
    partial void OnErrorMessageDetailsChanging(string value);
    partial void OnErrorMessageDetailsChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    #endregion
		
		public ErrorLog()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ErrorID
		{
			get
			{
				return this._ErrorID;
			}
			set
			{
				if ((this._ErrorID != value))
				{
					this.OnErrorIDChanging(value);
					this.SendPropertyChanging();
					this._ErrorID = value;
					this.SendPropertyChanged("ErrorID");
					this.OnErrorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorNumber", DbType="VarChar(50)")]
		public string ErrorNumber
		{
			get
			{
				return this._ErrorNumber;
			}
			set
			{
				if ((this._ErrorNumber != value))
				{
					this.OnErrorNumberChanging(value);
					this.SendPropertyChanging();
					this._ErrorNumber = value;
					this.SendPropertyChanged("ErrorNumber");
					this.OnErrorNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorMessage", DbType="VarChar(MAX)")]
		public string ErrorMessage
		{
			get
			{
				return this._ErrorMessage;
			}
			set
			{
				if ((this._ErrorMessage != value))
				{
					this.OnErrorMessageChanging(value);
					this.SendPropertyChanging();
					this._ErrorMessage = value;
					this.SendPropertyChanged("ErrorMessage");
					this.OnErrorMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorMessageDetails", DbType="VarChar(MAX)")]
		public string ErrorMessageDetails
		{
			get
			{
				return this._ErrorMessageDetails;
			}
			set
			{
				if ((this._ErrorMessageDetails != value))
				{
					this.OnErrorMessageDetailsChanging(value);
					this.SendPropertyChanging();
					this._ErrorMessageDetails = value;
					this.SendPropertyChanged("ErrorMessageDetails");
					this.OnErrorMessageDetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Documents")]
	public partial class Document : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DocID;
		
		private string _DocName;
		
		private string _DocCategory;
		
		private string _DocTitle;
		
		private string _DocDescription;
		
		private int _DocThirdPartyID;
		
		private int _CustomerID;
		
		private System.Nullable<int> _C_ID;
		
		private System.Nullable<bool> _IsPetitionFiled;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDocIDChanging(int value);
    partial void OnDocIDChanged();
    partial void OnDocNameChanging(string value);
    partial void OnDocNameChanged();
    partial void OnDocCategoryChanging(string value);
    partial void OnDocCategoryChanged();
    partial void OnDocTitleChanging(string value);
    partial void OnDocTitleChanged();
    partial void OnDocDescriptionChanging(string value);
    partial void OnDocDescriptionChanged();
    partial void OnDocThirdPartyIDChanging(int value);
    partial void OnDocThirdPartyIDChanged();
    partial void OnCustomerIDChanging(int value);
    partial void OnCustomerIDChanged();
    partial void OnC_IDChanging(System.Nullable<int> value);
    partial void OnC_IDChanged();
    partial void OnIsPetitionFiledChanging(System.Nullable<bool> value);
    partial void OnIsPetitionFiledChanged();
    #endregion
		
		public Document()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DocID
		{
			get
			{
				return this._DocID;
			}
			set
			{
				if ((this._DocID != value))
				{
					this.OnDocIDChanging(value);
					this.SendPropertyChanging();
					this._DocID = value;
					this.SendPropertyChanged("DocID");
					this.OnDocIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string DocName
		{
			get
			{
				return this._DocName;
			}
			set
			{
				if ((this._DocName != value))
				{
					this.OnDocNameChanging(value);
					this.SendPropertyChanging();
					this._DocName = value;
					this.SendPropertyChanged("DocName");
					this.OnDocNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocCategory", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string DocCategory
		{
			get
			{
				return this._DocCategory;
			}
			set
			{
				if ((this._DocCategory != value))
				{
					this.OnDocCategoryChanging(value);
					this.SendPropertyChanging();
					this._DocCategory = value;
					this.SendPropertyChanged("DocCategory");
					this.OnDocCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocTitle", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string DocTitle
		{
			get
			{
				return this._DocTitle;
			}
			set
			{
				if ((this._DocTitle != value))
				{
					this.OnDocTitleChanging(value);
					this.SendPropertyChanging();
					this._DocTitle = value;
					this.SendPropertyChanged("DocTitle");
					this.OnDocTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocDescription", DbType="VarChar(MAX)")]
		public string DocDescription
		{
			get
			{
				return this._DocDescription;
			}
			set
			{
				if ((this._DocDescription != value))
				{
					this.OnDocDescriptionChanging(value);
					this.SendPropertyChanging();
					this._DocDescription = value;
					this.SendPropertyChanged("DocDescription");
					this.OnDocDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocThirdPartyID", DbType="Int NOT NULL")]
		public int DocThirdPartyID
		{
			get
			{
				return this._DocThirdPartyID;
			}
			set
			{
				if ((this._DocThirdPartyID != value))
				{
					this.OnDocThirdPartyIDChanging(value);
					this.SendPropertyChanging();
					this._DocThirdPartyID = value;
					this.SendPropertyChanged("DocThirdPartyID");
					this.OnDocThirdPartyIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL")]
		public int CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_C_ID", DbType="Int")]
		public System.Nullable<int> C_ID
		{
			get
			{
				return this._C_ID;
			}
			set
			{
				if ((this._C_ID != value))
				{
					this.OnC_IDChanging(value);
					this.SendPropertyChanging();
					this._C_ID = value;
					this.SendPropertyChanged("C_ID");
					this.OnC_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPetitionFiled", DbType="Bit")]
		public System.Nullable<bool> IsPetitionFiled
		{
			get
			{
				return this._IsPetitionFiled;
			}
			set
			{
				if ((this._IsPetitionFiled != value))
				{
					this.OnIsPetitionFiledChanging(value);
					this.SendPropertyChanging();
					this._IsPetitionFiled = value;
					this.SendPropertyChanged("IsPetitionFiled");
					this.OnIsPetitionFiledChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
