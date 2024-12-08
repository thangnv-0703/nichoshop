export default class BaseApi {
  constructor() {
    let me = this;
  }
  getApiURL(route) {
    let me = this;
    return `https://localhost:44396/api/${me.apiVersion}/${me.controller}/${route}`;
  }
  create() {

  }
}
