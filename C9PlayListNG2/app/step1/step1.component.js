System.register(['@angular/core', '@angular/router', '../service/site.setting.service', '../service/playlist.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, site_setting_service_1, playlist_service_1;
    var Step1Component;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (site_setting_service_1_1) {
                site_setting_service_1 = site_setting_service_1_1;
            },
            function (playlist_service_1_1) {
                playlist_service_1 = playlist_service_1_1;
            }],
        execute: function() {
            Step1Component = (function () {
                function Step1Component(_siteSettingService, _playlistService) {
                    this._siteSettingService = _siteSettingService;
                    this._playlistService = _playlistService;
                    this.displayedList = [];
                }
                Step1Component.prototype.ngOnInit = function () {
                    var _this = this;
                    this._siteSettingService.getSiteSetting()
                        .subscribe(function (result) { return _this.siteSetting = result; }, function (error) { return _this.errorMessage = error; });
                    this._playlistService.getWholeList()
                        .subscribe(function (result) { return _this.wholePlaylist = result; }, function (error) { return _this.errorMessage = error; });
                };
                ;
                Step1Component.prototype.randomNumber = function (inValue) {
                    if (this.wholePlaylist && this.wholePlaylist.length) {
                        this.displayedList = [];
                        for (var i = 0; i < inValue; i++) {
                            this.displayedList.push(this.wholePlaylist[Math.round(Math.random() * this.wholePlaylist.length)]);
                        }
                    }
                };
                ;
                Step1Component = __decorate([
                    core_1.Component({
                        templateUrl: 'app/step1/step1.component.html',
                        directives: [router_1.ROUTER_DIRECTIVES]
                    }), 
                    __metadata('design:paramtypes', [site_setting_service_1.SiteSettingService, playlist_service_1.PlayListService])
                ], Step1Component);
                return Step1Component;
            }());
            exports_1("Step1Component", Step1Component);
        }
    }
});
//# sourceMappingURL=step1.component.js.map