import React,{useState} from 'react';
import {api} from '../api/client';
export default function LoginPanel({user,onLogin,onLogout,notify}) {
  const [mode,setMode]=useState('login');
  const [fullName,setFullName]=useState('');
  const [email,setEmail]=useState('minh@campus.edu');
  const [password,setPassword]=useState('Demo12345!');
  const [working,setWorking]=useState(false);
  async function login(e){e.preventDefault();setWorking(true);try{const res=await api('/auth/login',{method:'POST',body:JSON.stringify({email,password})});onLogin(res.user);notify('Đăng nhập thành công.');}catch(e){notify(e.message,true)}finally{setWorking(false)}}
  async function register(e){e.preventDefault();setWorking(true);try{await api('/auth/register',{method:'POST',body:JSON.stringify({fullName,email,password})});setMode('login');notify('Đăng ký thành công. Vui lòng đăng nhập.');}catch(e){notify(e.message,true)}finally{setWorking(false)}}
  async function logout(){setWorking(true);try{await api('/auth/logout',{method:'POST'});onLogout();notify('Đã đăng xuất.')}catch(e){notify(e.message,true)}finally{setWorking(false)}}
  return <div className="auth">
    {user?<><span>Xin chào, <b>{user.fullName}</b></span><button className="light" onClick={logout} disabled={working}>Đăng xuất</button></>
    :<>
      <form onSubmit={mode==='register'?register:login} className="login-form">
        {mode==='register'&&<label>Họ tên<input type="text" autoComplete="name" value={fullName} onChange={e=>setFullName(e.target.value)} maxLength={120} required/></label>}
        <label>Email<input type="email" autoComplete="email" value={email} onChange={e=>setEmail(e.target.value)} maxLength={180} required/></label>
        <label>Mật khẩu<input type="password" autoComplete={mode==='register'?'new-password':'current-password'} value={password} onChange={e=>setPassword(e.target.value)} minLength={mode==='register'?8:undefined} maxLength={128} required/></label>
        <button disabled={working}>{mode==='register'?'Đăng ký':'Đăng nhập'}</button>
      </form>
      <button type="button" className="auth-switch" onClick={()=>setMode(mode==='register'?'login':'register')} disabled={working}>
        {mode==='register'?'Đã có tài khoản? Đăng nhập':'Tạo tài khoản'}
      </button>
    </>}
  </div>;
}
