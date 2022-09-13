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
	[DefaultClassOptions]
	[DomainComponent]
	[NonPersistent]
	public class BlazorLayoutStorage : NonPersistentBaseObject
	{



		string layout;
		Guid permissionPolicyUser;
		string viewId;

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string ViewId
		{
			get => viewId;
			set => SetPropertyValue( ref viewId, value);
		}


		public Guid PermissionPolicyUser
		{
			get => permissionPolicyUser;
			set => SetPropertyValue( ref permissionPolicyUser, value);
		}

		
		[Size(SizeAttribute.Unlimited)]
		public string Layout
		{
			get => layout;
			set => SetPropertyValue( ref layout, value);
		}

	}
}
