import store from "@/stores/store";

export default {
    isAuthenticated: function () {
        return store.state.moduleUser.context?.token && !this.isJwtExpired(store.state.moduleUser.context?.token);
    },
    isJwtExpired: (token) => {
        if (!token) {
            return true;
        }
        const payloadBase64 = token.split('.')[1]

        if (!payloadBase64) {
            return true;
        }
        const payload = JSON.parse(atob(payloadBase64));

        if (!payload.exp) {
            return true;
        }

        const currentTime = Math.floor(Date.now() / 1000);
        return currentTime >= payload.exp;
    },
    getContext: function () {
        return store.state.moduleUser.context?.contextData;
    },
}