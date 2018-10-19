﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynamicGraphic.App_Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TestDB")]
	public partial class TestDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertMeasurement(Measurement instance);
    partial void UpdateMeasurement(Measurement instance);
    partial void DeleteMeasurement(Measurement instance);
    #endregion
		
		public TestDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TestDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Measurement> Measurement
		{
			get
			{
				return this.GetTable<Measurement>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Measurement")]
	public partial class Measurement : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _parameter_name;
		
		private int _parameter_value;
		
		private System.DateTime _date_time;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onparameter_nameChanging(string value);
    partial void Onparameter_nameChanged();
    partial void Onparameter_valueChanging(int value);
    partial void Onparameter_valueChanged();
    partial void Ondate_timeChanging(System.DateTime value);
    partial void Ondate_timeChanged();
    #endregion
		
		public Measurement()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parameter_name", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string parameter_name
		{
			get
			{
				return this._parameter_name;
			}
			set
			{
				if ((this._parameter_name != value))
				{
					this.Onparameter_nameChanging(value);
					this.SendPropertyChanging();
					this._parameter_name = value;
					this.SendPropertyChanged("parameter_name");
					this.Onparameter_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parameter_value", DbType="Int NOT NULL")]
		public int parameter_value
		{
			get
			{
				return this._parameter_value;
			}
			set
			{
				if ((this._parameter_value != value))
				{
					this.Onparameter_valueChanging(value);
					this.SendPropertyChanging();
					this._parameter_value = value;
					this.SendPropertyChanged("parameter_value");
					this.Onparameter_valueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_time", DbType="DateTime NOT NULL")]
		public System.DateTime date_time
		{
			get
			{
				return this._date_time;
			}
			set
			{
				if ((this._date_time != value))
				{
					this.Ondate_timeChanging(value);
					this.SendPropertyChanging();
					this._date_time = value;
					this.SendPropertyChanged("date_time");
					this.Ondate_timeChanged();
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
