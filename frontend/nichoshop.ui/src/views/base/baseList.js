import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";
import _ from 'lodash'
import { useConfirm } from "primevue/useconfirm";
import { useToast } from "primevue/usetoast";
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
      confirm: useConfirm(),
      toast: useToast()
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
    deleteOne(record) {
      this.confirm.require({
        message: `Bạn có chắc chắn muốn xóa ${this.$store.state[this.module].config?.name} này?`,
        header: 'Cảnh báo',
        icon: 'pi pi-info-circle',
        rejectLabel: 'Hủy',
        rejectProps: {
          label: 'Hủy',
          severity: 'secondary',
          outlined: true
        },
        acceptProps: {
          label: 'Đồng ý',
          severity: 'danger'
        },
        accept: () => {
          const fieldId = this.$store.state[this.module].config?.fieldId;
          this.handleDelete(record[fieldId])

        },
        reject: () => {
          close()
        }
      });
    },
    handleDelete(id) {
      this.$store.dispatch(`${this.module}/deleteItem`, id).then(res => {
        if (res) {
          this.toast.add({ severity: 'success', summary: 'Thành công', detail: 'Xóa thành công!', group: 'tc', life: 3000 });
        }
      })
    },
    getEditData() { },
  },
});
