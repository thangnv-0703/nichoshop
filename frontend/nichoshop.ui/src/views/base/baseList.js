import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";

export default defineComponent({
  name: "Baselist",
  computed: {
    items() {
      return this.$store.state[this.module].items;
    }
  },
  data() {
    return {
      detailModal: null,
      gridBase: null,
      module: null,
    };
  },
  mounted() {
    this.autoLoadGrid && this.loadDataGrid();
  },
  methods: {
    loadDataGrid() {
      this.$store.dispatch(`${this.module}/getAll`); //để tạm get all
    },
    edit(record) {
      const { open, close } = useModal({
        component: this.detailModal,
        attrs: {
          popupTitle: `Sửa ${this.$store.state[this.module].config?.name}`,
          editMode: this.$nicho.enumeration.editMode.Edit,
          record
        },
      });
      open();
    },
    add() {
      const { open, close } = useModal({
        component: this.detailModal,
        attrs: {
          popupTitle: `Thêm ${this.$store.state[this.module].config?.name}`,
          editMode: this.$nicho.enumeration.editMode.Add,
        },
      });
      open();
    },
    save(editMode) { },
    deleteOne() { },
    getEditData() { },
  },
});
