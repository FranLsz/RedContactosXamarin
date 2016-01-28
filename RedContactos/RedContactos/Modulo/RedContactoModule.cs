using System;
using Autofac;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using RedContactos.View;
using RedContactos.ViewModel;
using Xamarin.Forms;

namespace RedContactos.Modulo
{
    public class RedContactoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatos>().As<IServicioDatos>().SingleInstance();
            builder.Register<INavigation>(ctx => App.Current.MainPage.Navigation).SingleInstance();
            builder.RegisterType<Session>().SingleInstance();

            // PAGES
            builder.RegisterType<Login>().SingleInstance();
            builder.RegisterType<Registro>().SingleInstance();
            builder.RegisterType<Home>().SingleInstance();
            builder.RegisterType<ListadoUsuarios>().SingleInstance();
            builder.RegisterType<MensajesRecibidos>().SingleInstance();
            builder.RegisterType<MensajeDetalle>().SingleInstance();
            builder.RegisterType<UsuarioDetalle>().SingleInstance();
            builder.RegisterType<MensajeNuevo>().SingleInstance();
            builder.RegisterType<MensajesEnviados>().SingleInstance();

            // VIEWMODELS
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<RegistroViewModel>().SingleInstance();
            builder.RegisterType<HomeViewModel>().SingleInstance();
            builder.RegisterType<UsuariosListadoViewModel>().SingleInstance();
            builder.RegisterType<UsuarioDetalleViewModel>().SingleInstance();
            builder.RegisterType<MensajesRecibidosViewModel>().SingleInstance();
            builder.RegisterType<MensajeDetalleViewModel>().SingleInstance();
            builder.RegisterType<MensajeNuevoViewModel>().SingleInstance();
            builder.RegisterType<MensajesEnviadosViewModel>().SingleInstance();


            // action es un delegado, es un objeto que se le pasa para operar sobre otro objeto
            // func es una funcion
            /*se registra la pagina
            Constuimos un objeto de forma manual
            decimos la instancia de que queremos registrar
            registirstramos una instancia en concreto, en vez de un tipo
            hacemos esto para saber que pagina se esta ejecutando
                
            */
            builder.RegisterInstance<Func<Page>>(() =>
            {
                // accedemos al mainpage y pedimos la masterdetaulpage
                var masterP = App.Current.MainPage as MasterDetailPage;
                // una vez tenemos el master, objetemos el page, si es nulo, obtenemos el masterdetail entero
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                // lo mismo
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            });
            builder.RegisterType<DialogService>().
                 As<IDialogService>().
                 SingleInstance();
            builder.RegisterType<PageProxy>().
                 As<IPage>().
                 SingleInstance();
        }
    }
}