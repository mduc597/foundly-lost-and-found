import React,{useState} from 'react';
import {api} from '../api/client';
export default function LoginPanel({user,onLogin,onLogout,notify}) {
  const [email,setEmail]=useState('minh@campus.edu');
  const [password,setPassword]=useState('Demo12345!');
  const [working,setWorking]=useState(false);
  async function login(e){e.preventDefault();setWorking(true);try{const res=await api('/auth/login',{method:'POST',body:JSON.stringify({email,password})});onLogin(res.user);notify('Đăng nhập thành công.');}catch(e){notify(e.message,true)}finally{setWorking(false)}}
  async function logout(){setWorking(true);try{await api('/auth/logout',{method:'POST'});onLogout();notify('Đã đăng xuất.')}catch(e){notify(e.message,true)}finally{setWorking(false)}}
  return <div className="auth">
    {user?<><span>Xin chào, <b>{user.fullName}</b></span><button className="light" onClick={logout} disabled={working}>Đăng xuất</button></>
    :<form onSubmit={login} className="login-form"><label>Email<input type="email" value={email} onChange={e=>setEmail(e.target.value)} required/></label><label>Mật khẩu<input type="password" value={password} onChange={e=>setPassword(e.target.value)} required/></label><button disabled={working}>Đăng nhập demo</button></form>}
  </div>;
}
