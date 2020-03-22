using System;
using KMACSharp04Hak.Models;
using KMACSharp04Hak.Views.AddEditPerson;
using KMACSharp04Hak.Views.PersonList;

namespace KMACSharp04Hak.Tools.Navigation
{
    internal class AddEditPersonNavigationModel : BaseNavigationModel
    {
        public AddEditPersonNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AddEditPerson:
                    AddView(ViewType.AddEditPerson, new AddEditPersonView());
                    break;
                case ViewType.Main:
                    AddView(ViewType.Main, new PersonList());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
