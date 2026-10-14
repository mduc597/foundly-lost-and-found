import React,{useEffect,useState} from 'react';
import {api} from '../api/client';
const initial={type:'LOST',itemName:'',description:'',categoryId:'',locationId:'',eventTime:''};
export default function ReportForm({catalog,existing,onSaved,onClose,notify}) {
  const [form,setForm]=useState(initial);
  const [saving,setSaving]=useState(false);
  useEffect(()=>{setForm(existing?{
    type:existing.type,itemName:existing.itemName,description:existing.description,
    categoryId:String(existing.categoryId),locationId:String(existing.locationId),
    eventTime:toInput(existing.eventTime)
  }:initial)},[existing]);
  const set=(name,value)=>setForm(f=>({...f,[name]:value}));
  async function submit(e){e.preventDefault();
    if(!form.categoryId||!form.locationId||!form.description.trim()||!form.eventTime){notify('Hãy nhập đủ danh mục, mô tả, thời gian, khu vực.',true);return;}
    setSaving(true);
    try{
      const payload={...form,categoryId:Number(form.categoryId),locationId:Number(form.locationId),eventTime:new Date(form.eventTime).toISOString()};
      await api(existing?`/reports/${existing.id}`:'/reports',{method:existing?'PUT':'POST',body:JSON.stringify(payload)});
      notify(existing?'Đã cập nhật bài.':'Đăng tin thành công.');
      onSaved();
    }catch(e){notify(e.message,true)}finally{setSaving(false)}
  }
  return <form onSubmit={submit} className="report-form panel">
    <div className="section-title"><h2>{existing?'Sửa bài đăng':'US-01 · Đăng tin nhanh'}</h2><button type="button" className="light" onClick={onClose}>Đóng</button></div>
    <div className="fieldgrid">
      <label>Loại bài *<select disabled={!!existing} value={form.type} onChange={e=>set('type',e.target.value)}><option value="LOST">Báo mất đồ</option><option value="FOUND">Nhặt được đồ</option></select></label>
      <label>Tên món đồ *<input maxLength={140} minLength={3} required value={form.itemName} placeholder="Ví da màu nâu" onChange={e=>set('itemName',e.target.value)}/></label>
      <label>Danh mục *<select required value={form.categoryId} onChange={e=>set('categoryId',e.target.value)}><option value="">Chọn danh mục</option>{catalog.categories.map(c=><option key={c.id} value={c.id}>{c.name}</option>)}</select></label>
      <label>Khu vực *<select required value={form.locationId} onChange={e=>set('locationId',e.target.value)}><option value="">Chọn khu vực</option>{catalog.locations.map(c=><option key={c.id} value={c.id}>{c.name}</option>)}</select></label>
      <label>Thời gian mất / nhặt *<input type="datetime-local" required value={form.eventTime} onChange={e=>set('eventTime',e.target.value)}/></label>
    </div>
    <label>Mô tả *<textarea required minLength={10} maxLength={1500} rows={4} placeholder="Đặc điểm nhận biết, hoàn cảnh mất/nhặt…" value={form.description} onChange={e=>set('description',e.target.value)}/></label>
    <div className="form-bottom"><small>* Trường bắt buộc; API cũng kiểm tra lần nữa trước khi lưu PostgreSQL.</small><button disabled={saving}>{saving?'Đang lưu…':existing?'Lưu chỉnh sửa':'Đăng tin ngay'}</button></div>
  </form>;
}
function toInput(iso){if(!iso)return '';const d=new Date(iso);const z=n=>String(n).padStart(2,'0');return `${d.getFullYear()}-${z(d.getMonth()+1)}-${z(d.getDate())}T${z(d.getHours())}:${z(d.getMinutes())}`}
