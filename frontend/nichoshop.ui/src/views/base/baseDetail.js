import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";

export default defineComponent({
  name: "BaseDetail",
  data() {
    return { model: null };
  },
  created() {
    if (this.$attrs.editMode === this.$nicho.enumeration.editMode.Edit) {
      this.model = this.$attrs.record;
    }
  },
  mounted() {
  },
  methods: {

    onSubmit({ valid }) {
      if (!valid) {
        return;
      }
      this.save();
    },
    save() {
      switch (this.$attrs.editMode) {
        case this.$nicho.enumeration.editMode.Add:
          this.$store.dispatch(`${this.module}/createItem`, this.model);
          break;
        case this.$nicho.enumeration.editMode.Edit:
          this.$store.dispatch(`${this.module}/update`, this.model);
          break;
      }
    },
    getEditData() { },
  },
});
