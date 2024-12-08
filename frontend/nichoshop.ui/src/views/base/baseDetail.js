import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";

export default defineComponent({
  name: "BaseDetail",
  data() {
    return { model: null };
  },
  mounted() { },
  methods: {
    onSubmit({ valid }) {
      if (!valid) {
        return;
      }
      this.save();
    },
    save() {
      this.$store.dispatch(`${this.module}/createItem`, this.model);
      debugger;
    },
    getEditData() { },
  },
});
