// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,

  appConfig: {
    AppName: "D Admin",
    APIRetryCountOnFail: 1, 
  },
  UiConfigs: {
    snackBarDuration: 5000, 
  },
  endPoints: {
    Admin:{
      baseUrl: "http://localhost:5000/",
      getProductsAll: "adminapi/products",
      getProduct: "adminapi/product",
      getProductByKeywords: "adminapi/products",
      getKeywordsAll: "adminapi/keywords",
      addKeyword: "adminapi/keyword/add",
      deleteKeyword: "adminapi/keyword/delete",
      updateKeyword: "adminapi/keyword/update",
    }
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
