/* Iniate angular module weather app*/
angular
	.module('weatherApp',[
		'ui.router'
])
	/* dependency injection for angular routing*/
	.config(['$urlRouterProvider', '$stateProvider', function($urlRouterProvider,$stateProvider){
		$urlRouterProvider.otherwise('/');
 /* state provideer for each module or navigation page*/
			/* state provider for home */

		$stateProvider
			.state('home',{
				url: '/',
				templateUrl:  'templates/home.html',
				controller: 'homeCtrl'				
			})
			/* state provider for weather */
			$stateProvider
			.state('weather',{
				url: '/weather',
				templateUrl:  'templates/weather.html',
				controller: 'weatherCtrl'				
			})
			/* state provider for map */

			$stateProvider
			.state('map',{
				url: '/map',
				templateUrl:  'templates/map.html',
				controller: 'mapCtrl'				
			})
			/* state provider for about */

			$stateProvider
			.state('about',{
				url: '/about',
				templateUrl:  'templates/about.html',
				controller: 'aboutCtrl'
			})
	}]);