import { ModalsContainer, useModal } from "vue-final-modal";
import { defineComponent, getCurrentInstance } from "vue";
import _, { filter } from 'lodash'
import { useConfirm } from "primevue/useconfirm";
import { useToast } from "primevue/usetoast";
export default defineComponent({
  name: "Baselist",
  computed: {
    items() {
      return this.$store.state[this.module].items;
    },

  },
  data() {
    return {
      detailModal: null,
      gridBase: null,
      module: null,
      gridInfo: {
        pageNumber: 1,
        pageSize: 1,
        filters: null
      },
      confirm: useConfirm(),
      toast: useToast()
    };
  },
  mounted() {
    this.autoLoadGrid && this.loadDataGrid();
  },
  methods: {
    loadDataGrid(isLoadMore = false) {
      this.$store.dispatch(`${this.module}/getPaging`, {
        isLoadMore,
        pageNumber: this.gridInfo.pageNumber,
        pageSize: this.gridInfo.pageSize,
        filters: this.gridInfo.filters
      });
    },
    reload() {
      this.gridInfo.pageNumber = 1;
      this.loadDataGrid();
    },
    loadMore() {
      this.gridInfo.pageNumber++;
      this.loadDataGrid(true);
    },
    edit(record) {
      const { open, close } = useModal({
        component: this.detailModal,
        attrs: {
          popupTitle: `Sửa ${this.$store.state[this.module].config?.name}`,
          editMode: this.$nicho.enumeration.editMode.Edit,
          record: _.cloneDeep(record),
          close: () => close()
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
          close: () => close()
        },
      });
      open();
    },
    save(editMode) { },
    deleteOne(record) {
      let moduleConfigName = this.$store.state[this.module].config?.name;
      this.confirm.require({
        message: `Bạn có chắc chắn muốn xóa ${moduleConfigName ? moduleConfigName + 'này' : ""} ?`,
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
