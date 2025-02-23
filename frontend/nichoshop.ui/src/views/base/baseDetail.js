import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";
import { useToast } from "primevue/usetoast";

export default defineComponent({
  name: "BaseDetail",
  data() {
    return {
      model: null,
      loadEditData: null,
      editMode: this.$attrs.editMode,
      toast: useToast()
    };
  },
  async created() {
    if (this.editMode === this.$nicho.enumeration.editMode.Edit && this.$attrs.record) {
      this.model = this.$attrs.record;
    }
    if (this.loadEditData) {
      this.getEditData()
    }
  },

  computed: {
    entityErrors() {
      return this.$store.state[this.module].error;
    },
  },

  mounted() {
  },
  watch: {
    entityErrors: function (newValue) {
      // const errors = newValue.response?.data?.Errors;
      // if (errors) {
      //   for (const error in errors) {
      //     this.$refs[error]
      //   }
      // }
    }
  },
  methods: {

    onSubmit({ valid }) {
      if (!valid) {
        return;
      }
      this.save();
    },
    async save() {
      let param = this.model;
      param = this.customParam(param);
      let res = null;
      switch (this.editMode) {
        case this.$nicho.enumeration.editMode.Add:
          res = await this.$store.dispatch(`${this.module}/createItem`, param);
          break;
        case this.$nicho.enumeration.editMode.Edit:
          res = await this.$store.dispatch(`${this.module}/updateItem`, param);
          break;
      }
      if (res?.data) {
        this.$attrs.close()
        this.toast.add({ severity: 'success', summary: 'Thành công', detail: 'Lưu thành công!', group: 'tc', life: 3000 });
      }
    },
    customParam(param) { return param },
    async getEditData() {
      await this.$store.dispatch(`${this.module}/getItem`);
      this.model = this.$store.state[this.module].item;
    },
  },
});
