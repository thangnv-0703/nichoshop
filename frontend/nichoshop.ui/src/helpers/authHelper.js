import store from "@/stores/store";

export default {
    isAuthenticated: () => {
        return store.state.moduleUser.context?.token
        // && store.state.moduleUser.context?.expireTime < new Date()
    }
}