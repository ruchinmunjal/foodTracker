<template>
  <div class="container-fluid mt-4">
    <h1 class="h1">Food Records</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table table-striped">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Value</th>
              <th>Date Time</th>
              <th>&nbsp;</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="record in records" :key="record.id">
              <td>{{record.id}}</td>
              <td>{{record.name}}</td>
              <td>{{record.value}}</td>
              <td>{{record.dateTime}}</td>
              <td class="text-right">
                <a href="#" @click.prevent="updateFoodRecord(record)">Edit</a>
                <a href="#" @click.prevent="deleteFoodRecord(record.id)">Delete</a>
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="3">
        <b-card :title="(model.id ? 'Edit Food Id#' + model.id:'New Record')">
          <form @submit.prevent="createFoodRecord">
            <b-form-group label="Name">
              <b-form-input type="text" v-model="model.name"></b-form-input>
            </b-form-group>
            <b-form-group label="Value">
              <b-form-input type="number" rows="4" v-model.number="model.value"></b-form-input>
            </b-form-group>
            <b-form-group label="Date Time">
              <b-form-input type="datetime-local" rows="4" v-model="model.dateTime"></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Record</b-btn>
            </div>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import api from "@/FoodRecordApiService";

export default {
  data() {
    return {
      loading: false,
      records: [],
      model: {}
    };
  },
  async created() {
    this.getAll();
  },
  methods: {
    async getAll() {
      this.loading = true;
      try {
        this.records = await api.getAll();
      } finally {
        this.loading = false;
      }
    },
    async updateFoodRecord(foodRecord) {
      this.model = Object.assign({}, foodRecord);
    },
    async createFoodRecord() {
      const isUpdate = !!this.model.id;
      if (isUpdate) {
        await api.update(this.model.id, this.model);
      } else {
        await api.create(this.model);
      }
      this.model = {};
      await this.getAll();
    },
    async deleteFoodRecord(id) {
      if (confirm("Are you sure you want to delete this record?")) {
        if (this.model.id === id) {
          this.model = {};
        }
        await api.delete(id);
        await this.getAll();
      }
    }
  }
};
</script>
