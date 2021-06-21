export const environment = {
  production: true,

  
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
      getProductByKeywords: "adminapi/products",
      getKeywordsAll: "adminapi/keywords",
      addKeyword: "adminapi/keyword/add",
      deleteKeyword: "adminapi/keyword/delete",
      updateKeyword: "adminapi/keyword/update",
    }
  }
};
