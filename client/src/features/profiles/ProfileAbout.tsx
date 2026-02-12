import { useParams } from "react-router"
import { useProfile } from "../../lib/hooks/useProfile";
import { Box, Button, Divider, Paper, Typography } from "@mui/material";
import { profileSchema, type ProfileSchema } from "../../lib/schemas/profileSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import TextInput from "../../app/shared/component/TextInput";

export default function ProfileAbout() {

    const { id } = useParams();
    const [isEditing, handleEditing] = useState(false);
    const { profile,updateProfile, isCurrentUser } = useProfile(id);
    const { control, reset ,handleSubmit, formState: { isValid, isSubmitting } } = useForm<ProfileSchema>({
        mode: 'onTouched',
        resolver: zodResolver(profileSchema)
    });

    useEffect(() => {
        reset({
            displayName: profile?.displayName,
            bio: profile?.bio || ''
        });
    }, [profile, reset]);

    const onSubmit = async (data: ProfileSchema) => {
        await updateProfile.mutateAsync(data, {
            onSuccess: () => {
                handleEditing(false)
            }
        })
    }

    return (
        <Box>
            <Box display='flex' justifyContent='space-between'>
                <Typography variant="h5"> About {profile?.displayName}</Typography>
                {isCurrentUser && (
                    <Button onClick={() => handleEditing(!isEditing)}>
                        {!isEditing ? 'Edit profile' : 'Cancel'}
                    </Button>
                )}
            </Box>
            <Divider sx={{ my: 2 }} />
            <Box sx={{ overflow: 'auto', maxHeight: 350 }}>
                {!isEditing ? (
                    <Typography variant="body1" sx={{ whiteSpace: 'pre-wrap' }}>
                        {profile?.bio || 'No description added yet'}
                    </Typography>
                ) : (
                    <Paper sx={{ borderRadius: 3, padding: 3 }}>
                        <Box component='form' onSubmit={handleSubmit(onSubmit)} display='flex' flexDirection='column' gap={3}>
                            <TextInput label='Display Name' control={control} name='displayName' />
                            <TextInput label='Bio' control={control} name='bio' multiline rows={3}  />
                            <Button type="submit" variant="contained"
                                loading={isSubmitting}
                                disabled={!isValid}
                            >Submit</Button>
                        </Box>
                    </Paper>
                )}
            </Box>
        </Box>
    )
}