/// 
/// Directives
/// -------------------------------------------------------------------------------------------------------------------
/// <reference path="_references.ts" />

angular.module('app.directives', [])
    .directive('appVersion', [<any> 'version', function (version) {
        return function (scope, elm, attrs) {
            elm.text(version);
        };
	}])
	.directive('fileModelDirective', [function () {
		return {
			restrict: 'A',
			link: function (scope, element, attrs) {
				var model = $parse(attrs.fileModel);
				var modelSetter = model.assign;

				element.bind('change', function () {
					scope.$apply(function () {
						modelSetter(scope, element[0].files[0]);
					});
				});
			}
		};
	}]);