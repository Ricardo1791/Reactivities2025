import { z } from "zod";
import { requiredString } from '../util/util';

export const profileSchema = z.object({
    displayName: requiredString('displayName'),
    bio: z.string()
});

export type ProfileSchema = z.infer<typeof profileSchema>;