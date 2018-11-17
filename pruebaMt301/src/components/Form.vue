<template>
	<div >
		<h2>{{signup}}</h2>
		<div style="width: 100%; " >
				<span>Name:</span>
				<input id="name" type="text" v-model="userData.name" placeholder="Name"> <br />
				<span>Address:</span>
				<input id="address" type="text" v-model="userData.address" placeholder="Address"> <br />
				<span>Phone:</span>
				<input id="phone" type="text" v-model="userData.phone" placeholder="Phone"> <br />
				<span>Email:</span>
				<input id="email" type="email" v-model="userData.email" placeholder="Email"> <br />
				<span>Age:</span>
				<input id="age" type="number" v-model.number="userData.age" placeholder="Age" min="1" max="130"> <br />
				<button @click.prevent="submit">Submit!
				</button>
			<div v-if="isSubmitted">
				<p>Mail: <b>{{ response }}</b></p>
			</div>
		</div>
	</div>
</template>

<script>
	import axios from 'axios';
	export default {
		name: 'Form',
		data () {
			return {
				signup: 'Create a New Account',
				userData: {
			        name: '',
			        address: '',
			        phone: '',
			        email: '',
			        age:''
      			},
      			isSubmitted: true,
      			response:"nada"
			}
		},
		methods: {
			submit() {
				axios.post("https://pruebamt302f.azurewebsites.net/api/Saver?code=FtLxrycsJ01CCH05U5LFC21Kbn6zcc6PDxD95d5X2HwqwgT86kvzjQ==", { userData })
				.then(r => {
					//var result = response.content.toJSON();
					this.response = r;
				}, error => {
					this.response = error;
				});
				/*this.$http.post("https://pruebamt302f.azurewebsites.net/api/Saver?code=FtLxrycsJ01CCH05U5LFC21Kbn6zcc6PDxD95d5X2HwqwgT86kvzjQ==", userData,  { headers: { "content-type": "application/json" } })
				.then(r => {
					//var result = response.content.toJSON();
					this.response = r;
				}, error => {
					console.error(error);
					this.response = error;
				});*/
			}
		}
/*  		validations: {
  			userData: {
		        name: { required },
		        address: { required },
		        phone: { required },
		        email:  { required, email },
		        age:{ required }
  			}
  		}*/
	}
</script>
<style type="text/css">
	#formUser {
		font-size: 25px;
		width: 100%;
		text-align: center;
	}
</style>

