import { Hono } from 'hono';
import { env } from 'hono/adapter';
import { prompt } from './prompt';
import { RenameJsonKey } from './jsonkey';

const app = new Hono();

app.post('/', async (c) => {
  const { GEMINI_API_KEY } = env<{ GEMINI_API_KEY: string }>(c);
  const model = "gemini-2.0-flash"
  const url = `https://generativelanguage.googleapis.com/v1beta/models/${model}:generateContent?key=${GEMINI_API_KEY}`;
  const body = await c.req.json();
  const response = await fetch(url, {
    headers: {
      'Content-Type': 'application/json'
    },
    body: prompt(JSON.stringify(body))
  });
  const jsonResponse = await response.json() as any;
  let jsonText = jsonResponse.candidates[0].content.parts[0].text as string;
  const jsonObj = JSON.parse(RenameJsonKey(jsonText));

  return c.json(jsonObj);
});

export default app
