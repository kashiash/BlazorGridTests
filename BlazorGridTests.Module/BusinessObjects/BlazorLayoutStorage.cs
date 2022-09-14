using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGridTests.Module.BusinessObjects
{

	public class BlazorLayoutStorage 
	{





		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string ViewId
		{
			get;
			set;
		}


		public Guid PermissionPolicyUser
		{
			get;
			set;
		}

		
		[Size(SizeAttribute.Unlimited)]
		public string Layout
		{
			get;
			set;
		}

	}

	public static class MemoryStorage
	{ 
	
		public static List<BlazorLayoutStorage> LayoutList { get; set; }
	
	}
}
