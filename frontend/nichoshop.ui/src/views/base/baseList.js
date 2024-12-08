import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent } from "vue";

export default defineComponent({
  name: "Baselist",
  data() {
    return { detailModal: null, baseGrid: null };
  },
  mounted() {
    // this.autoLoadGrid && this.loadDataGrid(1);
  },
  methods: {
    // loadDataGrid() {
    //   module.d;
    // },
    edit() {
      const { open, close } = useModal({
        component: this.detailModal,
        attrs: {
          // async onBeforeOpen() {
          //   //todo: mask
          //   await getEditData();
          // },
          onSubmit(formData) {
            alert(JSON.stringify(formData, null, 2));

            save();
            close();
          },
        },
      });
      open();
    },
    add() {
      const { open, close } = useModal({
        component: this.detailModal,
        attrs: {
          onSubmit(formData) {
            alert(JSON.stringify(formData, null, 2));
            save();
            close();
          },
        },
      });
      open();
    },
    save(editMode) {},
    delete() {},
    getEditData() {},
  },
});
