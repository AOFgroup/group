﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostelPro
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HostelPro")]
	public partial class DataClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DataClassDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HostelProConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AvailibleBeds")]
		public ISingleResult<AvailibleBedsResult> AvailibleBeds([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DateStart", DbType="Date")] System.Nullable<System.DateTime> dateStart, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DateEnd", DbType="Date")] System.Nullable<System.DateTime> dateEnd)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dateStart, dateEnd);
			return ((ISingleResult<AvailibleBedsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.allHostels")]
		public ISingleResult<allHostelsResult> allHostels()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<allHostelsResult>)(result.ReturnValue));
		}
	}
	
	public partial class AvailibleBedsResult
	{
		
		private System.Nullable<int> _RoomId;
		
		private int _Bad_Number;
		
		private System.Nullable<System.DateTime> _DateEnd;
		
		public AvailibleBedsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomId", DbType="Int")]
		public System.Nullable<int> RoomId
		{
			get
			{
				return this._RoomId;
			}
			set
			{
				if ((this._RoomId != value))
				{
					this._RoomId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Bad Number]", Storage="_Bad_Number", DbType="Int NOT NULL")]
		public int Bad_Number
		{
			get
			{
				return this._Bad_Number;
			}
			set
			{
				if ((this._Bad_Number != value))
				{
					this._Bad_Number = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateEnd", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateEnd
		{
			get
			{
				return this._DateEnd;
			}
			set
			{
				if ((this._DateEnd != value))
				{
					this._DateEnd = value;
				}
			}
		}
	}
	
	public partial class allHostelsResult
	{
		
		private int _ID;
		
		private string _Name;
		
		private string _Address;
		
		private System.Nullable<int> _ZIP;
		
		private int _Phone;
		
		private string _Email;
		
		private string _Information;
		
		public allHostelsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(255)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this._Address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZIP", DbType="Int")]
		public System.Nullable<int> ZIP
		{
			get
			{
				return this._ZIP;
			}
			set
			{
				if ((this._ZIP != value))
				{
					this._ZIP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="Int NOT NULL")]
		public int Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this._Phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this._Email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Information", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Information
		{
			get
			{
				return this._Information;
			}
			set
			{
				if ((this._Information != value))
				{
					this._Information = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
