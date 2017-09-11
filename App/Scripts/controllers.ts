/// 
/// Controllers
/// -------------------------------------------------------------------------------------------------------------------
/// <reference path="_references.ts" />

angular.module('app.controllers', [])
    .controller('MainCtrl', [<any> '$scope', function ($scope) {
		if (navigator.geolocation) {
			navigator.geolocation.getCurrentPosition(function (position) {
				$scope.position = position;

				var pos = {
					lat: position.coords.latitude,
					lng: position.coords.longitude
				}

				$scope.map = new google.maps.Map(document.getElementById('map'), {
					center: pos,
					zoom: 12
				});

				$scope.infoWindow = new google.maps.InfoWindow();
				$scope.service = new google.maps.places.PlacesService($scope.map);

				// The idle event is a debounced event, so we can query & listen without
				// throwing too many requests at the server.
				$scope.map.addListener('idle', function () {
					var request = {
						location: pos,
						radius: '50000',
						types: ['restaurant'],
						name: 'McDonald'
					};
					$scope.service.nearbySearch(request, $scope.processResults);
				});

				$scope.processResults = function (results, status) {
					if (status !== google.maps.places.PlacesServiceStatus.OK) {
						console.error(status);
						return;
					}

					for (var i = 0; i < results.length; i++) {
						$scope.addMarker(results[i]);
					}
				};

				$scope.addMarker = function (place) {
					var marker = new google.maps.Marker({
						map: $scope.map,
						position: place.geometry.location,
						icon: {
							url: 'http://maps.gstatic.com/mapfiles/circle.png',
							//anchor: new google.maps.Point(16, 16),
							scaledSize: new google.maps.Size(20, 32)
						}
					});

					google.maps.event.addListener(marker, 'click', function () {
						$scope.service.getDetails(place, function (result, status) {
							if (status !== google.maps.places.PlacesServiceStatus.OK) {
								console.error(status);
								return;
							}
							$scope.infoWindow.setContent(result.name);
							$scope.infoWindow.open($scope.map, marker);

							/*replace the following block with a function to get actual images from backend*/

							$scope.toyLists.length = 0;

							var toyLists = [
								{ id: "1", src: "toy1.jpg" },
								{ id: "2", src: "toy2.jpg" },
								{ id: "3", src: "toy3.jpg" },
								{ id: "4", src: "toy4.jpg" },
								{ id: "5", src: "toy5.jpg" }
							];

							toyLists.push({ id: "6", src: "Like.png" });

							$scope.$apply(function () {
								$scope.imgSRC1.length = 0;
								$scope.imgSRC2.length = 0;

								angular.forEach(toyLists, function (t) {
									if (t.id % 2 == 1) {
										$scope.imgSRC1.push(t);
									}
									else {
										$scope.imgSRC2.push(t);
									}
								});

							});
							/**/
						});
					});
				};
			});
		}
    }])
    .controller('SecondCtrl', [<any> '$scope', function ($scope) {

    }]);;