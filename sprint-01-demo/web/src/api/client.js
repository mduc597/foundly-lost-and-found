// Shared API wrapper. All Sprint 1 feature modules use the same endpoint prefix.
export async function api(path,options={}) {
  const response=await fetch('/api'+path,{
    credentials:'same-origin',
    ...options,
    headers:{...(options.body?{'Content-Type':'application/json'}:{}),...options.headers}
  });
  const raw=await response.text();
  let data;
  try{data=raw?JSON.parse(raw):null;}catch{data=null;}
  if(!response.ok) throw new Error(data?.message || `HTTP ${response.status}`);
  return data;
}
