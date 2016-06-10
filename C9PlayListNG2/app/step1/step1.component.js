System.register(['@angular/core', '@angular/router', '../service/site.setting.service', '../service/playlist.service', '../pipe/item.sort.pipe'], function(exports_1, context_1) {
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
    var core_1, router_1, site_setting_service_1, playlist_service_1, item_sort_pipe_1;
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
            },
            function (item_sort_pipe_1_1) {
                item_sort_pipe_1 = item_sort_pipe_1_1;
            }],
        execute: function() {
            Step1Component = (function () {
                function Step1Component(_siteSettingService, _playlistService) {
                    this._siteSettingService = _siteSettingService;
                    this._playlistService = _playlistService;
                }
                Step1Component.prototype.ngOnInit = function () {
                    var _this = this;
                    this._siteSettingService.getSiteSetting()
                        .subscribe(function (result) { return _this.siteSetting = result; }, function (error) { return _this.errorMessage = error; });
                };
                ;
                Step1Component.prototype.randomIntInRange = function (min, max) {
                    return Math.floor(Math.random() * (max - min + 1)) + min;
                };
                Step1Component.prototype.shuffle = function () {
                    if (this.inMemoryList && this.inMemoryList.length) {
                        this.displayedList = [];
                        for (var i = 0; i < this.inMemoryList.length - 1; i++) {
                            this.displayedList.push(this.inMemoryList[this.randomIntInRange(0, this.inMemoryList.length - 1)]);
                        }
                    }
                };
                ;
                Step1Component.prototype.getResult = function (inText) {
                    var _this = this;
                    this.displayedList = [];
                    this._playlistService.getListByFreeText(inText, this.noofitems)
                        .subscribe(function (result) {
                        result.tracks.items.forEach(function (x) {
                            if (x.album !== null) {
                                if (x.album.images !== null) {
                                    _this.displayedList.push({
                                        imgUri: x.album.images[0].url,
                                        title: x.album.name,
                                        Id: x.album.id,
                                        link: x.external_urls.spotify
                                    });
                                }
                            }
                        });
                        /*
                         for (let i = 0; i < result.tracks.items.length; i++) {
                             if (result.tracks.items[i].album.images != null) {
                                     this.displayedList.push(
                                     {
                                         imgUri: result.tracks.items[i].album.images[0].url,
                                         title: result.tracks.items[i].album.name,
                                         Id: result.tracks.items[i].album.id,
                                         link: result.tracks.items[i].external_urls.spotify
                                     }
                                 )
                             }else{
                                 this.displayedList.push(
                                     {
                                         imgUri: "",
                                         title: result.tracks.items[i].album.name,
                                         Id: result.tracks.items[i].album.id,
                                         link: result.tracks.items[i].external_urls.spotify
                                     }
                                 )
                             }
             
             
                         }
                         */
                        _this.inMemoryList = _this.displayedList;
                    }, function (error) { return _this.errorMessage = error; });
                };
                ;
                Step1Component = __decorate([
                    core_1.Component({
                        templateUrl: 'app/step1/step1.component.html',
                        directives: [router_1.ROUTER_DIRECTIVES],
                        pipes: [item_sort_pipe_1.SongItemSortPipe]
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