using System;

using Unity;
namespace CooperativeLabor.WebApi
{
    using CooperativeLabor.Services;
    using CooperativeLabor.IServices;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IEntryAndExitRecordServices, EntryAndExitRecordServices>();
            container.RegisterType<IEssentialInformationServices, EssentialInformationServices>();

            //地址
            container.RegisterType<IPersonalInformationServices, PersonalInformationServices>();
            container.RegisterType<IEntryDimissionRecordServices, EntryDimissionRecordServices>();

            container.RegisterType<ISpecialSignTheRecordServices, SpecialSignTheRecordServices>();
            //权限
            container.RegisterType<IPermissionServices, PermissionServices>();
            //角色
            container.RegisterType<IRolesServices, RolesServices>();

            //补助标准配置
            container.RegisterType<IAllowancesServices, AllowancesServices>();
            //假期设置
            container.RegisterType<IHolidaySettingsServices, HolidaySettingsServices>();
         

            //考勤签到
            container.RegisterType<ICheckingInServices, CheckingInServices>();
            //差旅休假
            container.RegisterType<ITravelOnVacationServices, TravelOnVacationServices>();
            //人员费
            container.RegisterType<IPersonnelExpenditureServices, PersonnelExpenditureServices>();

            //单位科室
            container.RegisterType<IDepartmentMaintenanceServices, DepartmentMaintenanceServices>();

        }
    }
}