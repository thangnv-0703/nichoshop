import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";

export default defineComponent({
  name: "BaseDetail",
  data() {
    return { model: null, loadEditData: null, editMode: this.$attrs.editMode };
  },
  async created() {
    if (this.editMode === this.$nicho.enumeration.editMode.Edit && this.$attrs.record) {
      this.model = this.$attrs.record;
    }
    if (this.loadEditData) {
      await this.$store.dispatch(`${this.module}/getItem`);
      this.model = this.$store.state[this.module].item;
    }
  },
  mounted() {
  },
  methods: {

    onSubmit({ valid }) {
      debugger
      if (!valid) {
        return;
      }
      this.save();
    },
    save() {
      let param = this.model;
      debugger
      param = this.customParam(param);
      switch (this.editMode) {
        case this.$nicho.enumeration.editMode.Add:
          this.$store.dispatch(`${this.module}/createItem`, param);
          break;
        case this.$nicho.enumeration.editMode.Edit:
          this.$store.dispatch(`${this.module}/updateItem`, param);
          break;
      }
    },
    customParam(param) { return param },
    getEditData() { },
  },
});
