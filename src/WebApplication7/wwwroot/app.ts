

namespace mainApp {
let module: ng.IModule = angular.module('mainApp', ['ui.router', 'ui.bootstrap']);
    module.config((
        $stateProvider: ng.ui.IStateProvider,
        $locationProvider: ng.ILocationProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider
    ) => {
        $stateProvider.state('Home', {
            url: '/',
            templateUrl: 'home/home.view.html',
            controller: mainApp.Controllers.mainController,
            controllerAs: 'vm'
        })
            .state('Add', {
                url: '/add',
                templateUrl: 'add/add.view.html',
                controller: mainApp.Controllers.addController,
                controllerAs: 'vm'
            });
        $urlRouterProvider.otherwise('/');
        $locationProvider.html5Mode(true);
    });

}

  //  console.log('boom!');
