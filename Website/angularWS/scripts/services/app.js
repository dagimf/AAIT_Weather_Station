angular
	.module('weatherApp',[
		'ui.router'
])
	/* dependency injection*/
	.config(['$urlRouterProvider', '$stateProvider', function($urlRouterProvider,$stateProvider){
		$urlRouterProvider.otherwise('/');

		$stateProvider
			.state('home',{
				url: '/',
				templateUrl:  'templates/home.html',
				controller: 'homeCtrl'				
			})
			$stateProvider
			.state('weather',{
				url: '/weather',
				templateUrl:  'templates/weather.html',
				controller: 'weatherCtrl'				
			})
			$stateProvider
			.state('map',{
				url: '/map',
				templateUrl:  'templates/map.html',
				controller: 'mapCtrl'				
				})
			$stateProvider
			.state('about',{
				url: '/about',
				templateUrl:  'templates/about.html',
				controller: 'aboutCtrl'
			})
	}]);