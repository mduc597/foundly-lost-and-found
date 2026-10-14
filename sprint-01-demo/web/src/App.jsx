import React,{useCallback,useEffect,useState} from 'react';
import {api} from './api/client';
import LoginPanel from './components/LoginPanel';
import ReportForm from './features/US01_ReportForm';
import ReportList from './features/US02_ReportList';
import KeywordSearch from './features/US03_KeywordSearch';
import ReportFilters from './features/US04_ReportFilters';
import ReportDetail from './features/US05_ReportDetail';
const blank={type:'',categoryId:'',locationId:'',dateFrom:'',dateTo:''};
const emptyData={items:[],total:0,page:1,pageSize:12};
export default function App(){
  const [user,setUser]=useState(null),[catalog,setCatalog]=useState({categories:[],locations:[]});
  const [q,setQ]=useState(''),[filters,setFilters]=useState(blank),[data,setData]=useState(emptyData);
  const [page,setPage]=useState(1),[revision,setRevision]=useState(0),[formOpen,setFormOpen]=useState(false),[editing,setEditing]=useState(null);
  const [selected,setSelected]=useState(null),[notice,setNotice]=useState(null),[busy,setBusy]=useState(false);
  const notify=(text,error=false)=>setNotice({text,error});
  const load=useCallback(async()=>{
    const search=new URLSearchParams({page:String(page)});
    if(q)search.set('q',q);
    Object.entries(filters).forEach(([key,val])=>{if(val)search.set(key,val)});
    const result=await api(`/reports?${search.toString()}`);
    setData(result);
  },[q,filters,page,revision]);
  useEffect(()=>{Promise.all([api('/catalog'),api('/auth/me')]).then(([c,u])=>{setCatalog(c);setUser(u.user)}).catch(e=>notify(e.message,true));},[]);
  useEffect(()=>{let active=true;setBusy(true);load().catch(e=>{if(active)notify(e.message,true)}).finally(()=>{if(active)setBusy(false)});return()=>{active=false}},[load]);
  function changeFilters(next){setFilters(next);setPage(1)}
  function saved(){setFormOpen(false);setEditing(null);setPage(1);setFilters(blank);setQ('');setRevision(v=>v+1)}
  async function openDetail(id){try{setSelected(await api(`/reports/${id}`))}catch(e){notify(e.message,true)}}
  function edit(r){setSelected(null);setEditing(r);setFormOpen(true);window.scrollTo({top:0,behavior:'smooth'})}
  async function deleteReport(r){if(!window.confirm(`Xóa bài "${r.itemName}"?`))return;
    try{await api(`/reports/${r.id}`,{method:'DELETE'});setSelected(null);notify('Đã xóa bài.');setRevision(v=>v+1)}catch(e){notify(e.message,true)}}
  return <><header className="topbar"><div className="container top-inner"><div className="brand"><span className="brand-icon">✦</span><div><b>foundly<span>.</span></b><small>SPRINT 1 · CORE FEATURES</small></div></div><LoginPanel user={user} onLogin={setUser} onLogout={()=>{setUser(null);setFormOpen(false)}} notify={notify}/></div></header>
    <main className="container"><section className="intro"><span className="eyebrow">P0 • TUẦN 1</span><h1>Đồ thất lạc, tìm lại dễ dàng.</h1><p>Đăng tin nhanh, tập trung mọi bài trong một nơi, tìm theo từ khóa và lọc theo khu vực trong trường.</p><div className="actions"><button onClick={()=>{if(!user){notify('Đăng nhập tài khoản demo để đăng tin.',true);return}setEditing(null);setFormOpen(v=>!v)}}>{formOpen?'Ẩn biểu mẫu':'+ Đăng tin mất / nhặt được'}</button><a href="#report-list" className="light linkbutton">Xem danh sách ↓</a></div></section>
    {formOpen&&<ReportForm catalog={catalog} existing={editing} onClose={()=>{setFormOpen(false);setEditing(null)}} onSaved={saved} notify={notify}/>}
    <div className="search-area"><KeywordSearch value={q} onSearch={v=>{setQ(v);setPage(1)}}/><ReportFilters catalog={catalog} filters={filters} onChange={changeFilters} onClear={()=>{changeFilters(blank);setQ('')}}/></div>
    {busy&&<div className="progress">Đang tải danh sách...</div>}
    <ReportList data={data} onDetail={openDetail} onPage={setPage}/>
    <footer>Foundly Sprint 1 · US-01 → US-05 · Demo độc lập để báo cáo tuần đầu.</footer></main>
    {selected&&<ReportDetail report={selected} user={user} onClose={()=>setSelected(null)} onEdit={edit} onDelete={deleteReport}/>}
    {notice&&<div className={'toast '+(notice.error?'error':'')} role="status"><span>{notice.text}</span><button onClick={()=>setNotice(null)}>✕</button></div>}
  </>;
}
