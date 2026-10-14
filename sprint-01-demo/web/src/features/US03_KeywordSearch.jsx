import React,{useEffect,useState} from 'react';
export default function KeywordSearch({value,onSearch}) {
  const [q,setQ]=useState(value);
  useEffect(()=>setQ(value),[value]);
  return <form className="searchbox" onSubmit={e=>{e.preventDefault();onSearch(q.trim())}}>
    <label htmlFor="q"><strong>US-03 · Tìm kiếm từ khóa</strong></label>
    <div className="searchrow"><input id="q" maxLength={100} placeholder="Tên hoặc mô tả món đồ…" value={q} onChange={e=>setQ(e.target.value)}/><button>Tìm kiếm</button></div>
  </form>;
}
