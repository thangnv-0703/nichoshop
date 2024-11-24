<template>
  <div>
    <div class="logo"></div>
    <Form
      v-slot="$form"
      :resolver="resolver"
      :initialValues="initialValues"
      @submit="onFormSubmit"
      class="flex flex-col gap-4 w-full sm:w-64"
    >
      <div class="flex flex-col gap-1">
        <InputGroup>
          <InputGroupAddon>
            <i class="pi pi-user"></i>
          </InputGroupAddon>
          <InputText v-model="text1" placeholder="Username" />
        </InputGroup>
        <Password
          name="password"
          placeholder="Password"
          :feedback="false"
          fluid
        />
        <template v-if="$form.password?.invalid">
          <Message
            v-for="(error, index) of $form.password.errors"
            :key="index"
            severity="error"
            size="small"
            variant="simple"
            >{{ error.message }}</Message
          >
        </template>
      </div>
      <Button type="submit" severity="secondary" label="Submit" />
    </Form>
  </div>
</template>
<script setup lang="ts">
import { ref } from "vue";
import { VueFinalModal } from "vue-final-modal";
import { zodResolver } from "@primevue/forms/resolvers/zod";
// import { useToast } from "primevue/usetoast";
import { z } from "zod";
import { useRouter } from "vue-router";
// const toast = useToast();
const initialValues = ref({
  password: "",
});
const router = useRouter();
const resolver = ref(
  zodResolver(
    z.object({
      password: z
        .string()
        .min(3, { message: "Minimum 3 characters." })
        .max(8, { message: "Maximum 8 characters." })
        .refine((value) => /[a-z]/.test(value), {
          message: "Must have a lowercase letter.",
        })
        .refine((value) => /[A-Z]/.test(value), {
          message: "Must have an uppercase letter.",
        }),
      // .refine((value) => /d/.test(value), {
      //   message: "Must have a number.",
      // }),
    })
  )
);
const onFormSubmit = ({ valid }) => {
  if (valid) {
    router.push("/home");
  }
};
</script>

<style scoped lang="scss">
.logo {
  height: 40px;
  width: 213px;
  background-image: url("@/assets/images/NS Logo.svg");
}
/* Thêm CSS tùy chỉnh nếu cần */
</style>
