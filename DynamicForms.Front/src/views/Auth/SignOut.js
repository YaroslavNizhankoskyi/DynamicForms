export default function SignOut() {
  localStorage.clear();
  window.location.assign("/");
}
