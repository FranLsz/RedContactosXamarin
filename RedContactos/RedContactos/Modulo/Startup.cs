using Autofac;
using MvvmLibrary.Factorias;
using MvvmLibrary.Modulo;
using RedContactos;
using RedContactos.Modulo;
using RedContactos.View;
using RedContactos.ViewModel;
using Xamarin.Forms;

namespace RedSocial.Modulo
{
    public class Startup : AutofacBootstrapper
    {
        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<RedContactoModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<RegistroViewModel, Registro>();
            viewFactory.Register<HomeViewModel, Home>();
            viewFactory.Register<UsuariosListadoViewModel, ListadoUsuarios>();
            viewFactory.Register<UsuarioDetalleViewModel, UsuarioDetalle>();
            viewFactory.Register<MensajesRecibidosViewModel, MensajesRecibidos>();
            viewFactory.Register<MensajesEnviadosViewModel, MensajesEnviados>();
            viewFactory.Register<MensajeNuevoViewModel, MensajeNuevo>();
            viewFactory.Register<MensajeDetalleViewModel, MensajeDetalle>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>(vm =>
            {
                vm.Titulo = "Inicio de sesión";
            });
            // pondrá la barra de navegacion arriba
            var np = new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}