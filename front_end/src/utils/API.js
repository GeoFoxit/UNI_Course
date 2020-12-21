import axios from "axios";

export const API = axios.create({
    baseURL: "http://localhost:50271/api/",
    responseType: "json",
    // headers: { "Authorization": "" }
});

export const token = () => {

}