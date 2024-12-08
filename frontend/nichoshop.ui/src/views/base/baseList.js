import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";
import _ from 'lodash'
import { useToast } from "primevue/usetoast";
import { useConfirm } from "primevue/useconfirm";
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
          record: _.cloneDeep(record)
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
    deleteOne() {
      const confirm = useConfirm();
      const toast = useToast();
      confirm.require({
        message: `Bạn có chắc chắn muốn xóa ${this.$store.state[this.module].config?.name} này?`,
        header: 'Danger Zone',
        icon: 'pi pi-info-circle',
        rejectLabel: 'Cancel',
        rejectProps: {
          label: 'Cancel',
          severity: 'secondary',
          outlined: true
        },
        acceptProps: {
          label: 'Delete',
          severity: 'danger'
        },
        accept: () => {
          toast.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted', life: 3000 });
        },
        reject: () => {
          toast.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected', life: 3000 });
        }
      });
    },
    getEditData() { },
  },
});
