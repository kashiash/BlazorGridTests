using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace BlazorGridTests.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SoupToNut : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public SoupToNut(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}



        EnumerableType enumerableType;
        string someNotes;
        string onceMoreString;
        string anotherString;
        int someInteger;
        bool someBoolean;
        DateTime somedate;
        decimal someDecimal;
        string someString;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SomeString
        {
            get => someString;
            set => SetPropertyValue(nameof(SomeString), ref someString, value);
        }


        public decimal SomeDecimal
        {
            get => someDecimal;
            set => SetPropertyValue(nameof(SomeDecimal), ref someDecimal, value);
        }


        public DateTime Somedate
        {
            get => somedate;
            set => SetPropertyValue(nameof(Somedate), ref somedate, value);
        }


        public bool SomeBoolean
        {
            get => someBoolean;
            set => SetPropertyValue(nameof(SomeBoolean), ref someBoolean, value);
        }


        public int SomeInteger
        {
            get => someInteger;
            set => SetPropertyValue(nameof(SomeInteger), ref someInteger, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AnotherString
        {
            get => anotherString;
            set => SetPropertyValue(nameof(AnotherString), ref anotherString, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OnceMoreString
        {
            get => onceMoreString;
            set => SetPropertyValue(nameof(OnceMoreString), ref onceMoreString, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string SomeNotes
        {
            get => someNotes;
            set => SetPropertyValue(nameof(SomeNotes), ref someNotes, value);
        }

        
        public EnumerableType EnumerableType
        {
            get => enumerableType;
            set => SetPropertyValue(nameof(EnumerableType), ref enumerableType, value);
        }
    }

    public enum EnumerableType
    { 
    Kind1,Kind2,Kind3,SomethingOther,Nothing
    }
}