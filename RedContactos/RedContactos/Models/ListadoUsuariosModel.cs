using System.Windows.Input;
using Autofac;
using DataModel.ViewModel;
using RedContactos.ViewModel;
using Xamarin.Forms;

namespace RedContactos.Models
{
    public class ListadoUsuariosModel
    {
        public ICommand CmdAdd { get; set; }
        public UsuarioModel UsuarioModel { get; set; }
        public IComponentContext ComponentContext { get; set; }

        public ListadoUsuariosModel()
        {
            CmdAdd = new Command(RunComandoAdd);
        }

        private void RunComandoAdd()
        {
            var vm = ComponentContext.Resolve<UsuariosListadoViewModel>();
            vm.ListadoUsuarios.Add(UsuarioModel);
        }
    }
}